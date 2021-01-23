    var schools = db.Schools
         .Where(x => x.State == "<Whatever>")
         .Select(x => new {
              School = x,
              Bobs = x.Where(y => y.MiddleName == "Bob")
         }).ToList();
    
    List<Schools> schoolsView = new List<Schools>();
    foreach(var x in schools)
    {
         schoolsView.Add(new SchoolsViewModel(){
              //Set Properties here
              SchooldID = x.School.ID,
              SchoolName = x.School.Name,
              Students = x.Bobs.ToList() //You can project here if needed.
         };
    }
    
    return schoolsView;
