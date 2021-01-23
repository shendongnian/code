    using System;
    using System.IO.Ports;
    using System.Reflection;
    class Program
    {
        static void OnErrorReceived(object sender, SerialErrorReceivedEventArgs e){}
        static void Main(string[] args)
        {
            var serialPort = new SerialPort();
            // Add a handler so we actually get something out.
            serialPort.ErrorReceived += OnErrorReceived;  
            
            foreach (var eventInfo in serialPort.GetType().GetEvents())
            {
                var field = serialPort.GetType().GetField(eventInfo.Name, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField);
                if (field != null)
                {
                    var backingDelegate = (Delegate)field.GetValue(serialPort);
                    if (backingDelegate != null)
                    {
                        var subscribedDelegates = backingDelegate.GetInvocationList();
                        foreach (var subscribedDelegate in subscribedDelegates)
                        {
                            Console.WriteLine(subscribedDelegate.Method.Name + " is hooked on " + eventInfo.Name);
                        }
                    }          
                }                     
            }
        }
    }
