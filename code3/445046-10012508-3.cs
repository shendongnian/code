    public class TaskChangedEventArgs : EventArgs
    {
        public TaskChangedEventArgs(int taskId)
        {
            TaskId = taskId;
        }
        public int TaskId { get; private set; }
    }
    public class TaskControl : UserControl
    {
       public event EventHandler<TaskChangedEventArgs> TaskChanged;
       
       // raise it inside button click event handler
       protected void OnTaskChanged(int taskId)
       {
           if (TaskChanged != null)
               TaskChanged(this, new TaskChangedEventArgs(taskId));
       }
    }
