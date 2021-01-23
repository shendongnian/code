            AppDomain.CurrentDomain.FirstChanceException += (sender, e) =>
            {
                if ((e == null) || (e.Exception == null))
                {
                    return;
                }
                using (var sw = File.AppendText(@".\exceptions.txt")) 
                {
                    sw.WriteLine(e.ExceptionObject);
                }                
            };
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                if ((e == null) || (e.ExceptionObject == null))
                {
                    return;
                }
                using (var sw = File.AppendText(@".\exceptions.txt")) 
                {
                    sw.WriteLine(e.ExceptionObject);
                }                
            };
