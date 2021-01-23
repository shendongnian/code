    private string m_order_date;
    public string order_date
    {
        get
        {
            try
            {
                string ukDateTimeFormat = Convert.ToString(DateTime.Parse(m_order_date, CultureInfo.CreateSpecificCulture("en-US")));
    
                return ukDateTimeFormat;
            }
            catch (FormatException e)
            {
                return "Error";
            }
        }
    
        set
        {
            m_order_date = value;
        }
    }
