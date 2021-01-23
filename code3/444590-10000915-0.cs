    public class MyCustomTab : TabItem
    {
       ...
       
    
       protected override OnPaint(....)
       {
          if(this.Parent == null) return;
    
           base.Paint(...);
       }    
    }
