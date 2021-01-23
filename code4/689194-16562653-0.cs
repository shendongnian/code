            Process[] p = Process.GetProcesses();
            String Title = String.Empty;
            for (var i = 0; i < p.Length; i++)
            {
                Title = p[i].MainWindowTitle;
                if (Title.Contains(@"Adobe"))
                    Console.WriteLine(Title);
            }
