     <appSettings>		
		<add key="location_1" value="123"/>
		<add key="avgValue_1" value="123"/>
		<add key="usability_1" value="123"/>
		<add key="location_2" value="123"/>
		<add key="avgValue_2" value="123"/>
		<add key="usability_2" value="123"/>
		<add key="count" value="2"/>
	 </appSettings>
    public class SomeClass
    {
    private string location;
    private double avgValue;
    private int usability;
    public string Location 
    {
        get { return location; }
        set { location = value; }
    }
    public double AvgValue
    {
        get { return avgValue; }
        set { avgValue = value; }
    }
    public int Usability
    {
        get { return usability; }
        set { usability = value; }
    }
    }
    public class Config
    {
    public static List<SomeClass> Items
    {
        get
        {
            List<SomeClass> result = new List<SomeClass>();
            for (int i = 1; i <= Convert.ToInt32(WebConfigurationManager.AppSettings["count"]); i++)
            {
                SomeClass sClass = new SomeClass();
                sClass.AvgValue = Convert.ToDouble(WebConfigurationManager.AppSettings["avgValue_" + i.ToString()]);
                sClass.Location = WebConfigurationManager.AppSettings["location_" + i.ToString()];
                sClass.Usability = Convert.ToInt32(WebConfigurationManager.AppSettings["usability_" + i.ToString()]);
            }
            return result;
        }
    }
}
