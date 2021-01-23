    [Register("CustomTextField")]
    public class CustomTextField : UITextField
    {
    public CustomTextField() : base() {}
    
    public CustomTextField(IntPtr handle) : base(handle)
    {
         Delegate = new CustomDelegate();
    }
    
    private class CustomDelegate : UITextFieldDelegate
    {
         public override bool ShouldChangeCharacters(UITextField textField, NSRange range, string replacementString)
         {
              int maxCharacters = 8;
              var newContent = new NSString(textField.Text).Replace(range, new NSString(replacement)).ToString();
              int number;
              return newContent.Length <= maxCharacters && (replacement.Length == 0 || int.TryParse(replacement, out number));
         }
    }
