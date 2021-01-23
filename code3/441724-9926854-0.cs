    public interface IBuilder
    {
         void Show();
    }
    public abstract class Task
    {
        // ...
        public abstract IBuilder GetBuilder(TaskList todoList);
        // ...
    }
    public class Note : Task
    {
        public override IBuilder GetBuilder(TaskList todoList)
        {
            return new noteBuilder(todoList);
        }
        // ...
    }
    // etc.
    private void itemEdit_Click(object sender, EventArgs e)
    {
        int edi = taskNameBox.SelectedIndex;
        Task checkTask = todoList.ElementAt(edi);
        IBuilder builder = checkTask.GetBuilder(todoList);
        builder.Show();
    }
