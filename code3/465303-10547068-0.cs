    private void FormInterface_Load(object sender, EventArgs e)
    {
    ITask[] TaskAry = new[]{ new TaskClass() };
    TaskComposite tc = new TaskComposite(TaskAry);
    tc.Do(); //This Will Start Your Task, In Case you Want To Start It Here.
    }
    class TaskClass : ITask
    {
    public void Do()
    {
        Console.WriteLine(DateTime.Now.ToString());
    }
    }
