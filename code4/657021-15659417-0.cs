    var persons = new BindingList<Person>();
    var bindingSource = new BindingSource();
    bindingSource.DataSource = dates;
    comboBox.DataSource = bindingSource;
    // Suspend change the list from another thread,
    // and resume on the gui thread.
    bindingSource.SuspendBinding();
    Task.Factory.StartNew(() => dates.Add(DateTime.Now))
                .ContinueWith(finishedTask => bindingSource.ResumeBinding(),
                                TaskScheduler.FromCurrentSynchronizationContext());
