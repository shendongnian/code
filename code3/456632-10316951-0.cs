    public class WebService : System.Web.Services.WebService {
        [WebMethod]
        [return: XmlRoot(ElementName = "Projects")]
        public ProjectDTO[] HelloWorld()
        {
            return new ProjectDTO[] { new ProjectDTO(), new ProjectDTO(), new ProjectDTO(), }; 
        }       
    }
    
    [XmlType(TypeName = "Project")]
    public class ProjectDTO
    {
        public string Blah { get; set; }
    }
