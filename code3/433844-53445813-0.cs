    [ScriptService]
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    
    public class Randezvous : WebService
    {
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void getUnitPersonels(string user, string pass, decimal unitNo)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            #region ..:: Kullanıcı şİfre Kontrol ::..
            if (!(unit == "xxx" && pass == "yyy"))
            {
    
                string msg = "User or pass is wrong.";
                Context.Response.Write(serializer.Serialize(msg));
                return;
            }
            #endregion
    
            List<Personels> personels = _units.getUnitPersonels(unitNo);
    
            string jsonString = serializer.Serialize(personels);
            Context.Response.Write(jsonString);
        }
    }
