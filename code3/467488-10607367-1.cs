    private object FormatPhoneNumber(string phoneNumber)
    {
       // return nothing if the string is null
       if(String.IsNullOrEmpty(phoneNumber))
       {
           return "";    
       }
       // invalid phone number submitted
       if(phoneNumber.Length != 10)
       {
           throw new System.ArgumentException("Phone Number must contain 10 digits", "phoneNumber");
       }
       // probably want one more check to ensure the string contains numbers and not characters, but then again, hopefully that's handled on input validation.
       // if the int is valid, return the formatted text
       return string.Format("({0}) {1}-{2}",
              phoneNumber.Substring(0, 3),
              phoneNumber.Substring(3, 3),
              phoneNumber.Substring(6));
    }
