    public class ExecuteTasks
    {
        private System.Timers.Timer myTimer = new System.Timers.Timer();
        private Int32 TaskIndex = 0;
        private Int32 TaskCount = 3;
        protected void StartExecution()
        {
            myTimer.Interval = 1;
            myTimer.Elapsed += new System.Timers.ElapsedEventHandler(myTimer_Elapsed);
            myTimer.Start();
        }
        void myTimer_Elapsed(object sender, EventArgs e)
        {
            myTimer.Stop();
            if (TaskIndex < TaskCount)
            {             
                Task aTask = GetTasks()[TaskIndex++];
                StartTask(aTask.TaskName);
                SetNextTaskTimer(aTask.NextInterval);
            }
        }
        void SetNextTaskTimer(Int32 Seconds)
        {   
            myTimer.Interval = (Seconds * 1000) - DateTime.Now.Millisecond - 1;//Interval is set in miliseconds
            myTimer.Start();
        }
        void StartTask(String TaskName)
        {
            ProcessStartInfo objStartInfo = new ProcessStartInfo();
            objStartInfo.FileName = TaskName;
            Process objProcess = new Process();
            objProcess.StartInfo = objStartInfo;
            objProcess.Start();
        }
        //You will be reading your tasks from your database or a file
        List<Task> GetTasks()
        {
            List<Task> lstTasks = new List<Task>();
            lstTasks.Add(new Task("Task A", 2, 1));
            lstTasks.Add(new Task("Task B", 10, 2));
            lstTasks.Add(new Task("Task C", 60, 3));
            return lstTasks.OrderBy(le => le.Priority).ToList();
        }
    }
