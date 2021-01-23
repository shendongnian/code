    [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]
        // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
        [System.Web.Script.Services.ScriptService]
        public class JsonData : System.Web.Services.WebService
        {
    
            [WebMethod(Description = "")]
            [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
            public StateData[] GetStateByCountryID(int ID)
            {
                StateData objStateData = new StateData();
                LMGDAL.db_LMGEntities dbData = new db_LMGEntities();                
                var data = (from con in dbData.tblStates
                            where con.State_CountryID == ID
                            select new StateData
                            {
                                StateID = con.StateID,
                                StateName = con.StateName
                            }).ToList();
                return data.ToArray();
            }
