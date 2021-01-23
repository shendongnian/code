    public class DataBaseLayer ()
    {
    
    public DataBaseLayer()
    { /* check for appSetting here and throw a SqlServerMaintenanceModeException exception (custom exception) */}
    
    }
    public class EmployeeDataLayer :  DataBaseLayer ()
        {
    public EmployeeDataLayer() : base ()
    }
