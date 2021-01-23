    public class StringIntBool {
       private bool _isSet;
       private bool _isString;
       public bool IsString {
           get { return _isString; }
       }
       // ...
       
       private string _innerString;
       public string InnerString {
           get {
               return _innerString;
           }
           set {
               if (_isSet) {
                   throw new Exception("StringIntBool is already set");
               }
               _isSet = true;
               _isString = true;
               _innerString = value;
           }
       }
       // etc...
    }
