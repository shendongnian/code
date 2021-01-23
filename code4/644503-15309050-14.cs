    public class Form2
    {
      public event EventHandler<MyEventArgs> OnMyChange;
    
      //call it then you need to update:
      if(OnMyChange!= null)
      {
        MyEventArgs e = new MyEventArgs();
        List<string> content = new List<string>();
        content.Add("abc");
        e.EventInfo = content;
    	OnMyChange(this, e);
      }
    }
    
