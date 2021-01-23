    /// <summary>
    /// Summary description for PartMarking
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    [System.Web.Script.Services.ScriptService]
    public class PartMarking : System.Web.Services.WebService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PartMarking()
        {
            _unitOfWork = DependencyResolver.Current.GetService<IUnitOfWork>();
        }
        [WebMethod]
        public DataSet GetParentConfigurations(string engineModel, string componentCode)
        {
            var results = _unitOfWork.PartMarking.GetParentSicMarkings(engineModel, componentCode);
            return results;
        }
    }
