    [DefaultPropertyAttribute("SaveOnClose")]
    public class AppSettings{
    private bool saveOnClose = true;
    private string tempUnit;
    private int tempValue;
    [CategoryAttribute("Global Settings"),
    ReadOnlyAttribute(false),
    DefaultValueAttribute("Celsius")]
    public string TemperatureUnit
    {
        get { return tempUnit; }
        set { tempUnit = value; }
    }
    [CategoryAttribute("Global Settings"),
    ReadOnlyAttribute(false),
    DefaultValueAttribute(0)]
    public string TemperatureValue
    {
        get { return tempValue; }
        set { tempValue = value; }
    }
    }
