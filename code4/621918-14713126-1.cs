    //StringWriter requires System.IO
    using System.IO;
    //This are hypothetical Class and WebMethod names, of course
    public class RequisitionApprovers : System.Web.Services.WebService
    {
        [WebMethod]
        public string ReturnRequisitionApproversAsXMLString(DataSet ds)
        {
            //so as you can see, we're starting off with a DataSet,
            //this is what your code returns
            
            DataTable dt = ds.Tables[0];
            StringWriter writer = new StringWriter();
            dt.WriteXml(writer);
            string xmlResult = writer.ToString();
            
            return xmlResult;
        }
    }
