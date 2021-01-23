      public partial class Category
      {
        public bool IsUnderCategory(Category categ)
        {
          if (Id == categ.Id) return true; // is itself
    
          if (Parent == null)
            return false;
    
          return Parent.IsUnderCategory(categ);
        }
      }
