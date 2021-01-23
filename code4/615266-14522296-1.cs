    public class ComboBoxItem
    {
         public string Display{get;set;}
         public string Value{get;set;}
         public override ToString()
         {
              return this.Display.ToString();
         }
    }
