    public class Mark
    {
    
        // this will hold the selected value
    
        public string ProfessorID { get; set; }
    
        public IEnumerable<SelectListItem> Professors
        { 
            get
            {
                return Proffessors                
                    .Select(x => new SelectListItem {
                        Value = x.ProfessorId.ToString(),
                        Text = String.Concat(p.FirstName, " ", p.LastName)
                    });
            } 
        }
    
     public IEnumerable<Professor> Proffessors     
      {
         get
         {
             IProfessorRepository professorsRepo = new ProfessorRepository();
              return professorsRepo.All;
         }
     }
    
      //the rest of your code
    }
