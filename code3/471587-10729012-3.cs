    using System.Globalization;
    
    namespace WpfApplication
    {
        public class Person : IProposedValueErrorInfo
        {
            public int Age { get; set; }
            public string Surname { get; set; }
    
            #region IProposedValueErrorInfo Members
    
            object IProposedValueErrorInfo.GetError(string propertyName, object value, CultureInfo cultureInfo)
            {
                switch (propertyName)
                {
                    case "Age":
                        int dummy;
                        return value is int || int.TryParse(value as string, NumberStyles.Integer, cultureInfo, out dummy) ? null : "Age must be a number.";
                }
    
                return null;
            }
    
            #endregion
        }
    }
