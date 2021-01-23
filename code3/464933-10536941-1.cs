    private void simpleButton1_Click(object sender, EventArgs e)
    {
        _subject = new Subject<int>();
         _subject.SubscribeOn(Scheduler.TaskPool).ObserveOn(SynchronizationContext.Current).Synchronize().Subscribe(UpdateTextBox);
    _bag = new ConcurrentBag<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    this.Validated += OnValidated;
    }
    public void OnValidated(bool validate)
    {
            if(validate)
            {
                //submit
            }
    }
