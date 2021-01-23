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
            foreach (var proc in Process.GetProcesses()
                                        .Where(p => !String.IsNullOrEmpty(p.MainWindowTitle)))
            {
                ProcessList.Add(proc.MainWindowTitle);
            }
        }
