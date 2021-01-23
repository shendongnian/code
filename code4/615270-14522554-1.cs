    public class MyEventArg : EventArgs {
        
        public bool Handled {get;set;}
    
    }
    myEvent += new MyEventHandler(met1);
    
    public void met2(object sender, MyEventArgs e)
    {
    
       if(e.Handled)
          return;
    
       if(myCondition)
       {
           e.Handled = true;
           return;
       }
    ...
    }
