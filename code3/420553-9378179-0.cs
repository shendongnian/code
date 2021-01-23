    public void lotsOfAsync()
    {
        DoAsync1();
        for each ( MyClass in Async1List)
         {    
              MyClass.PropertyChange += new MyClass.PropertyChangeHandler(Async2Complete);
              MyClass.DoAsyn2(); 
          }
     }
    
     public void Async2Complete(object sender, PropertyChangeEventArgs data)
            {
                if (data.PropertyName == "AsyncComplete")
                {
                    totalAsyncCompleted++;
                    if (totalAsyncCompleted >= Async1List.Count)
                    {
                        FinalAction();
                    }
                }
            }
