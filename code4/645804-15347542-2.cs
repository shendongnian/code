    public class ValidateQuantity : ValidateAttribute
    {
      private const string MESSAGE = "Error Message";
      public ValidateQuantity (int qtyInput, int qtyConfirm)
          : base( MESSAGE )
      {
         Input = qtyInput;
         Confirm = qtyConfirm;
      }
      
      public int Input {get; private set;}
      public int Confirm {get; private set;}
    
      public override bool IsValid (object value)
      {
        var properties = TypeDescriptor.GetProperties(value);
        var input = properties.Find(Input, false).GetValue(value); 
        var confirm = properties.Find(Confirm, false).GetValue(value); 
        if( input > confirm)
        {
          return false;
        }
        return true;
      }
    }
