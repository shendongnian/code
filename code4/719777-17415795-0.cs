    using System.Text.RegularExpressions;
    
    Regex regex = new Regex(@"^.*(?=.{4,10})(?=.*\d)(?=.*[a-zA-Z]).*$");
    if (regex.Match(passwordBox1.Password).Success)
    {
      //the password match the rule
    }
