     public class ProcessInfo
    {
        private Process[] myProcess = Process.GetProcessesByName("notepad"); //Process is underlined here with red wavy line saying "A get or set accessor mehtod is expected" 
        public Process SomeProcess
        {
            get
            {
                return myProcess[0];
            }
        }
        public string PName
        {
            get
            {
                return SomeProcess.ProcessName;
            }
        }
        public int PID
        {
            get
            {
                return SomeProcess.Id;
            }
        }
    } 
