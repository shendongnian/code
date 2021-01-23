    public class MyObjectBuilder
    {
         Checked _checked;
         public  MyObjectBuilder()
         {
              Reset()
         }
         private void Reset()
         { 
              _checked = new Checked(true); //etc
         }
         public MyObjectBuilder WithChecked(bool checked)
         {
              _checked = new Checked(checked);
         }
         public MyObject Build()
         {
             var built = new MyObject(){Checked = _checked;} 
             Reset();
             return built;
         }
    }
