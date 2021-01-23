    public class Note: Task
    {
        (...)
        public override void ShowEditForm(IList todoList)
        {
            (new noteBuilder(taskToEdit)).Show();
        }
        (...)
    }
    public class Reminder: Task
    {
        (...)
        public override void ShowEditForm(IList todoList)
        {
            (new reminderBuilder(taskToEdit)).Show();
        }
        (...)
    }
