     public class CategoryController : ApiController
     {
         public List<Category> Get(String categoryIDs)
         {
             List<Category> categoryRepo = new List<Category>();
 
             String[] idRepo = categoryIDs.Split(',');
 
             foreach (var id in idRepo)
             {
                 categoryRepo.Add(new Category()
                 {
                     CategoryID = id,
                     CategoryName = String.Format("Category_{0}", id)
                 });
             }
             return categoryRepo;
         }
     }
 
     public class Category
     {
         public String CategoryID { get; set; }
         public String CategoryName { get; set; }
     } 
