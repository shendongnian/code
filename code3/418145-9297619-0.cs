    public class Sports 
    { 
       private string _name;
       public string Name
       {
           get { return _name; }
           set { if (value == PredefinedStrings.Golf
                     || value == PredefinedStrings.Basketball
                     || value == PredefinedStrings.Hulahoops)
                  {
                      _name = value;
                  }
                  else
                  {
                      throw new ArgumentException ("Invalid value");
                  }
                }
       }
    }
