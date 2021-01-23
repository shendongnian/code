    public void findModules(string executablePath)
        {
             Process process = new Process();
             process.StartInfo.FileName = executablePath;
             process.Start();
             process.WaitForInputIdle();
             System.Threading.Thread.Sleep(10000);
    
             ProcessModuleCollection mods = process.Modules;
    
             foreach (ProcessModule m in mods)
             {
                Console.WriteLine(m.ModuleName + ":" + m.FileName);
             }
      }
