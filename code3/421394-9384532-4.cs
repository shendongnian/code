    var mc = new MyClassThatDoesSomething();
    mc.Listener = s =>
    {
       Console.WriteLine(s);
       //update progress bar, whatever
    }
    mc.ProcessList(); 
