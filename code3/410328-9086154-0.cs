    public class CategoryWithSubcategories
    {
       public Category SomeCategory {get;set;}
       public IEnumerable<SubCategory> RelatedSubCategories {get;set;}
    }
