    using System.Diagnostics;
    
    namespace DynamicTraceLog
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Use TraceSource, not Trace, they are easier to turn off
                TraceSource trace = new TraceSource("app");
                //SourceSwitches allow you to turn the tracing on and off.
                SourceSwitch level =new SourceSwitch("app");
                //I assume you want to be dynamic, so probalby some user input would be here:
                if(args.Length>0 && args[0]=="Off")
                    level.Level= SourceLevels.Off;
                else
                    level.Level = SourceLevels.Verbose;
                trace.Switch = level;
                //remove default listner to improve performance
                trace.Listeners.Clear();
                //Listeners implement IDisposable
                using (TextWriterTraceListener file = new TextWriterTraceListener("log.txt"))
                using (ConsoleTraceListener console = new ConsoleTraceListener())
                {
                    //The file will likely be in /bin/Debug/log.txt
                    trace.Listeners.Add(file);
                    //So you can see the results in screen
                    trace.Listeners.Add(console);
                    //Now trace, the console trace appears immediately.
                    trace.TraceInformation("Hello world");
                    //File buffers, it flushes on Dispose or when you say so.
                    file.Flush();
                }
                System.Console.ReadKey();
            }
        }
    }
