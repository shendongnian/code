    void MyCompositeTask()
    {
      var result = First();
      Second(first);
    }
    Task.Factory.StartNew(() => MyCompositeTask());
