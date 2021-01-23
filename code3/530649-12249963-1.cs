    private static List<string> static_strings = new List<string>();//this won't be
                                                                    //collected unless we
                                                                    //assign null or another
                                                                    //List<string> to static_strings
    public void AddOne()
    {
      string a = new Random().Next(0, 2000).ToString();//a is in scope, it refers
                                                       //to a string that won't be collected.
      static_strings.Add(a);//now both a and the list are ways to reach that string.
      SomeListHolder b = new SomeListHolder(static_strings);//can be collected
                                                            //right now. Nobody cares
                                                            //about what an object refers
                                                            //to, only what refers to it.
    }//a is out of scope.
    public void RemoveOne()
    {
      if(static_strings.Count == 0) return;
      a = static_strings[0];//a is in scope.
      static_strings.RemoveAt(0);//a is the only way to reach that string.
      GC.Collect();//Do not try this at home.
      //a is in scope here, which means that we can write some code here
      //that uses a. However, garbage collection does not depend upon what we
      //could write, it depends upon what we did write. Because a is no
      //longer used, it is highly possible that it was collected because
      //the compiled code isn't going to waste its time holding onto referenes
      //it isn't using.
    }
