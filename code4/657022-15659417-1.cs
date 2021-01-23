    var persons = new BindingList<Person>();
    var bindingSource = new BindingSource();
    bindingSource.DataSource = persons;
    comboBox.DataSource = bindingSource;
    // Suspend change the list from another thread,
    // and resume on the gui thread.
    bindingSource.SuspendBinding();
    Task.Factory.StartNew(() => persons.Add(Person.GetRandomFromDatabase()))
                .ContinueWith(finishedTask => bindingSource.ResumeBinding(),
                                TaskScheduler.FromCurrentSynchronizationContext());
