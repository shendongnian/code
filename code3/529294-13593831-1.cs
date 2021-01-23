    public class ApiFileCategoriesController : ApiBaseController
    {
        public ApiFileCategoriesController(IMshIntranetUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
       
        public IEnumerable<FileCategory> GetFiles()
        {
            return UnitOfWork.FileCategories.GetAll().OrderBy(x=>x.CategoryName);
        }
        public FileCategory GetFile(int id)
        {
            return UnitOfWork.FileCategories.GetById(id);
        }
        //Post api/ApileFileCategories
       
        public HttpResponseMessage Post(FileCategory fileCategory)
        {
            UnitOfWork.FileCategories.Add(fileCategory);
            UnitOfWork.Commit(); 
            return new HttpResponseMessage();
        }
    }
