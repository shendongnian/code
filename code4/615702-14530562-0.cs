    // you could use any type from the assembly here
    var assembly = typeof(TaskManagerHelper).Assembly;
    using (var stream = assembly.GetManifestResourceStream("TaskManager.Data.DataBase.TasksDataBase.xml"))
    using (var xmlReader = XmlReader.Create(stream))
    {
        // ... do something with the XML here
    }
