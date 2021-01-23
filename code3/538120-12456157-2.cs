    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class ClientUserServices : System.Web.Services.WebService
    {
        [WebMethod]
        public string[] GetAllSpecialities(int index)
        {
            return Enumerable.Range(1, 20).Select(id => Guid.NewGuid().ToString()).ToArray();
        }
    }
