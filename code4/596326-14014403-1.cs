    void DoJob1And2()
    {
       try
       {
           Job1();
       }
       finally
       {
           Job2();
       }
    }
    void Job1()
    {
       // Do job 1
    }
    void Job2()
    {
       // Do job 2
    }
