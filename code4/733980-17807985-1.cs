    class FamilyViewModel
    {
      public List<Family> Families {get;set;}
      public void ChildHasFamily(Child child)
      {
          var hasFamily = Families.SelectMany(f => f.Children)
                                  .Any(c => c.Name == child.Name);
      } 
    }
