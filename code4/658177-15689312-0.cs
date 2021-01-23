    public class CompanyService: ICompanyService
    {
       private readonly HttpContextBase _context;
 
       public CompanyService(HttpContextBase context)
       {
          _context = context;      
       }
       public HttpResponseMessage Delete(int id)
       {
           _context.Request ....
       }
    }
 
