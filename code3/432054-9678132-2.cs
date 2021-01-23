     public class CourseController : Controller 
     { 
         private UnitOfWork unitOfWork = new UnitOfWork(); 
      
         // 
         // GET: /Course/ 
      
         public ViewResult Index() 
         { 
             var courses = unitOfWork.CourseRepository.Get(includeProperties: "Department"); 
             return View(courses.ToList()); 
        }
        
        ....
    }
    
