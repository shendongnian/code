    //StringWriter requires System.IO
    using System.IO;
    //This are hypothetical Class and WebMethod names, of course
    public class RequisitionApprovers : System.Web.Services.WebService
    {
        [WebMethod]
        public string ReturnRequisitionApproversAsXMLString(DataSet ds)
        {
            StringWriter writer = new StringWriter();
            ds.WriteXml(writer, XmlWriteMode.IgnoreSchema);
            string xmlResult = writer.ToString();
            
            return xmlResult;
        }
    }
