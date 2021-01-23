    public class CustomerService : System.Web.Services.WebService
    {
        [WebMethod]
        public string GetNationality(int nationalityId)
        {
            return nationalityId == 1 ? "Nationality1" : "Nationality2";
        }
    }
