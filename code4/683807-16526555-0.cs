    public partial class MyEntity        
    {
        public string MyField_string
        {
            get
            {
                return MyField.ToString();
            }
            set
            { 
                decimal res = 0;
                var b = Decimal.TryParse(value, out res);
                if (!b)
                    throw new ArgumentException("Localized message");
                else
                    this.MyField = Math.Round(res, 2);
            }
        }
        
        partial void OnMyFieldChanged()
        {
            RaisePropertyChanged("MyField_string");
        }
    }
