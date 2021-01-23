     public string FormattedPhoneNumber {
         get {
             return PhoneNumber.IsEmpty()
             ? "Not Available"
             : PhoneNumber.ToPhoneNumber();
         }
     }
