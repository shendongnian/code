    //define Proj here!
    List<Train> Proj = null;
    if (pick == null || pick == "active")
        {
           Proj = db.usp_Train(idnbr)
                     .Where(a => a.Inactive == false).ToList();
         }        
         else 
         {
           Proj = db.usp_Train(idnbr).ToList();
    
         }
    
    return PartialView(Proj);
