    var loadOperation = context.Load(context.GetStudentsQuery());
    operation.Completed += OnStudentsLoaded;
    private void OnStudentsLoaded(object sender, EventArgs e)
    {
        var operation = sender as LoadOperation<Student>;
        if (operation == null)
        {
            throw new ArgumentException("sender is not LoadOpearation<Student>");
        }
        IEnumerable<Student> students = operation.Entities;
        //.....
    }
