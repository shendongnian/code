    void ServiceARequest()
    {
      using (new ActivityScope())
      {
        //Do some stuff
        using (new LogicalOperationScope("SomeWork"))
        {
          DoSomeWork();
          for (int i = 0; i < 10; i++)
          {
            using (new LogicalOperationScope(string.Format("nested {0}", i))
            {
              DoNestedWork(i);
            }
          }
        }
      }
    }
    void DoSomeWork()
    {
      using (new LogicalOperationScope("DoSomeWork"))
      {
      }
    }
    void DoNestedWork(int level)
    {
    }
   
