    using System;
    using System.IO;
    using System.Threading;
    using System.Windows;
    namespace Node
    {
        class Program
        {
            public static void Main()
            {
                var app = new Application();
                app.Startup += ServerStart;
                app.Run();
            }
            private static void ServerStart(object sender, StartupEventArgs e)
            {
                var dispatcher = ((Application) sender).Dispatcher;
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                var path = Environment.ExpandEnvironmentVariables(
                    @"%SystemRoot%\Notepad.exe");
                var fs = new FileStream(path, FileMode.Open,
                    FileAccess.Read, FileShare.ReadWrite, 1024 * 4, true);
                var bytes = new byte[1024];
                fs.BeginRead(bytes, 0, bytes.Length, ar =>
                {
                    dispatcher.BeginInvoke(new Action(() =>
                    {
                        var res = fs.EndRead(ar);
                        // Are we in the same thread?
                        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                    }));
                }, null);
            }
        }
    }
