    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    public class ProcessListGenerator
    {
        public ProcessListGenerator()
        {
            ProcessList = new BindingList<String>();
        }
        public BindingList<String> ProcessList
        {
            get;
            private set;
        }
        public void UpdateProcessList()
        {
            ProcessList.Clear();
            foreach (var process in Process.GetProcesses())
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    ProcessList.Add(process.MainWindowTitle);
                }
            }
        }
