    class Wizard
    {
        private IList<IProcess> processes = new List<IProcess();
        
        public T GetProcess<T>(string name) 
               where T : IProcess
        {
            return (T)processes.Single(x => x.Name == name);
        }
        public void Run()
        {
           foreach (var proc in processes) 
                  proc.Run(this);
        }
    }
