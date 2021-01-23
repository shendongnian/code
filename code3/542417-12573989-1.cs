    public class ClassName(){
    protected void getStaffData(int staffID)
    {
     GetCustStaff(staffID, ConfigurationManager.AppSettings.Get("Connection").ToString())
    ...//fill method 
    }
}
