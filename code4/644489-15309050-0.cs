    public class Form2
    {
      public event MyEventHandler OnMyChange;
    
      //call it then you need to update:
      if(OnMyChange!= null)
      {
    	OnMyChange(this, new EventArgs());
      }
    }
    
