    public void MainFlow()
    {
       Task taskWork = Task.Factory.StartNew(new Action(DoWork));
       //Do other work
       //Then wait for thread finish
       taskWork.Wait();
    }
    private void DoWork()
    {
       //Do work
    }
