    public class KeywordProperties
    {    
      public KeywordProperties()
      {
        MyCountry = "Country1";
      }
      private string myCountry;
      [TypeConverter(typeof(ObjectNameConverter))]
      public string MyCountry
      {
        get { return myCountry; }
        set 
        {
          if (value != myCountry)
            MyCity = "";
          myCountry = value; 
        }
      }
      private string myCity;
      [TypeConverter(typeof(ObjectNameConverter))]
      public string MyCity
      {
        get { return myCity; }
        set { myCity = value; }
      }   
    }
    public class ObjectNameConverter : StringConverter
    {
      public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
      {
        return true;
      }
      public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
      {
        KeywordProperties myKeywordProps = context.Instance as KeywordProperties;
        if (context.PropertyDescriptor.Name == "MyCountry")
        {
          List<string> listOfCountries = new List<string>();
          listOfCountries.Add("Country1");
          listOfCountries.Add("Country2");        
          return new StandardValuesCollection(listOfCountries);
        }      
        List<string> listOfCities = new List<string>();
        if (myKeywordProps.MyCountry == "Country1")
        {
          listOfCities.Add("City11");
          listOfCities.Add("City12");
          listOfCities.Add("City13");
        }
        else
        {
          listOfCities.Add("City21");
          listOfCities.Add("City22");
          listOfCities.Add("City23");
        }
        return new StandardValuesCollection(listOfCities);
      }
    }
