    static readonly ILog s_Log = LogManager.GetType("SerialWorkaroundLogger");
   
    static void SafeDisconnect(SerialPort port, Stream internalSerialStream)
    {
        GC.SuppressFinalize(port);
        GC.SuppressFinalize(internalSerialStream);
 
        ShutdownEventLoopHandler(internalSerialStream);
 
        try
        {
            s_Log.DebugFormat("Disposing internal serial stream");
            internalSerialStream.Close();
        }
        catch (Exception ex)
        {
            s_Log.DebugFormat(
                "Exception in serial stream shutdown of port {0}: {1}", port.PortName, ex);
        }
 
        try
        {
            s_Log.DebugFormat("Disposing serial port");
            port.Close();
        }
        catch (Exception ex)
        {
            s_Log.DebugFormat("Exception in port {0} shutdown: {1}", port.PortName, ex);
        }
    }
 
    static void ShutdownEventLoopHandler(Stream internalSerialStream)
    {
        try
        {
            s_Log.DebugFormat("Working around .NET SerialPort class Dispose bug");
 
            FieldInfo eventRunnerField = internalSerialStream.GetType()
                .GetField("eventRunner", BindingFlags.NonPublic | BindingFlags.Instance);
 
            if (eventRunnerField == null)
            {
                s_Log.WarnFormat(
                    "Unable to find EventLoopRunner field. "
                    + "SerialPort workaround failure. Application may crash after "
                    + "disposing SerialPort unless .NET 1.1 unhandled exception "
                    + "policy is enabled from the application's config file.");
            }
            else
            {
                object eventRunner = eventRunnerField.GetValue(internalSerialStream);
                Type eventRunnerType = eventRunner.GetType();
 
                FieldInfo endEventLoopFieldInfo = eventRunnerType.GetField(
                    "endEventLoop", BindingFlags.Instance | BindingFlags.NonPublic);
 
                FieldInfo eventLoopEndedSignalFieldInfo = eventRunnerType.GetField(
                    "eventLoopEndedSignal", BindingFlags.Instance | BindingFlags.NonPublic);
 
                FieldInfo waitCommEventWaitHandleFieldInfo = eventRunnerType.GetField(
                    "waitCommEventWaitHandle", BindingFlags.Instance | BindingFlags.NonPublic);
 
                if (endEventLoopFieldInfo == null
                    || eventLoopEndedSignalFieldInfo == null
                    || waitCommEventWaitHandleFieldInfo == null)
                {
                    s_Log.WarnFormat(
                        "Unable to find the EventLoopRunner internal wait handle or loop signal fields. "
                        + "SerialPort workaround failure. Application may crash after "
                        + "disposing SerialPort unless .NET 1.1 unhandled exception "
                        + "policy is enabled from the application's config file.");
                }
                else
                {
                    s_Log.DebugFormat(
                        "Waiting for the SerialPort internal EventLoopRunner thread to finish...");
 
                    var eventLoopEndedWaitHandle =
                        (WaitHandle)eventLoopEndedSignalFieldInfo.GetValue(eventRunner);
                    var waitCommEventWaitHandle =
                        (ManualResetEvent)waitCommEventWaitHandleFieldInfo.GetValue(eventRunner);
 
                    endEventLoopFieldInfo.SetValue(eventRunner, true);
 
                    // Sometimes the event loop handler resets the wait handle
                    // before exiting the loop and hangs (in case of USB disconnect)
                    // In case it takes too long, brute-force it out of its wait by
                    // setting the handle again.
                    do
                    {
                        waitCommEventWaitHandle.Set();
                    } while (!eventLoopEndedWaitHandle.WaitOne(2000));
 
                    s_Log.DebugFormat("Wait completed. Now it is safe to continue disposal.");
                }
            }
        }
        catch (Exception ex)
        {
            s_Log.ErrorFormat(
                "SerialPort workaround failure. Application may crash after "
                + "disposing SerialPort unless .NET 1.1 unhandled exception "
                + "policy is enabled from the application's config file: {0}",
                ex);
        }
    }
