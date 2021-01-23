    public class PaymentDetails
    {
         private int _id;
         private bool _idSet = false;
         int Id
         {
             get
             {
                 return _id;
             }
             set
             {
                 if (_idSet == false)
                 {
                     _id = value;
                     _idSet == true;
                 }
                 else
                 {
                     throw new ArgumentException("Cannot change an already set value.");
                 }
             }
         }
         private string _status;
         private bool _statusSet = false;
         string Status
         {
             get
             {
                 return _status;
             }
             set
             {
                 if (_statusSet == false)
                 {
                     _status = value;
                     _statusSet = true;
                 }
                 else
                 {
                     throw new ArgumentException("Cannot change an already set value.");
                 }
             }
         }
