    bool validPhoneNumber = Common.IsValidTelephoneNumber(this.PhoneNumber);
    
    //Insert Regular Expression
    Regex regex = new Regex(@"^((\((\+|00){3}\)|(\()?\d{3}()?|)\d{10})$")
    
    string number = this.PhoneNumber;
    
    // Replace unwanted Characters
    number.Replace(" ", "");
    number.Replace("-", "");
    number.Replace("(", "");
    number.Replace(")", "");
    number.Replace(":", "");
    
    Match match  = regex.Match(number);
    
    PhoneNumber (Contact)
    char[] phonenumber = this.phoneNumber.ToCharArray();
    StringBuilder builder = new StringBuilder(10);
    for (int i = 0; i < phonenumber.Length; i++)
    {
        if (phonenumber[i] >= '0' && phonenumber[i] <= '9')
        {
            builder.Append(phonenumber[i]);
        }
    }
    phoneNumber = builder.ToString().Substring(0, Math.Min(10, builder.Length));
