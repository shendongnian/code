    public void DoSomething(string command)
        {
            
            var p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.FileName = command;
            try
            {
                p.Start();
                p.WaitForExit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
