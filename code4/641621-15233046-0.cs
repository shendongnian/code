    private Siblings GetSiblings(string name, string school, string id)
    {
    Siblings siblings = new Siblings()
      {
         Name = name,
         School = school,
         Id= id
    
       }
    
    return siblings;
    }
    
    
    private CreateSiblingsList()
    {
       List<Siblings> list = new List<Siblings>();
      // First Sibling, carry on for rest siblings
       list.Add(GetSiblings(sib1name.Text,sibling1school.Text,sib1id.Text)); 
    }
