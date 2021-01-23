    // Before foreach
    var tasks = new List<Task>();
    
    // Inside foreach
    if (myDate == DateTime.Now)
    {
        MessageBox.Show("Updates are New");
    }
    else
    {
        tasks.Add(Download(m.Value,filename.Value));
    }
    
    // after foreach
    // You can also set the TimeSpan value and update the progressbar
    // periodically until all the tasks are finished
    Task.WaitAll(tasks.ToArray());
