    void MyCompositeTask()
    {
      var result = First();
      Second(result);
    }
    Task.Factory.StartNew(() => MyCompositeTask());
