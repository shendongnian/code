    public class PersonContempancyViewModel
    {
        // update with properties the view needs
    }
    [HttpPost] 
    public ActionResult Create(PersonContempancyViewModel viewModel) 
    { 
        if (ModelState.IsValid) 
        {
            var entity = new PersonContempancyEntity();
            // map properties from view model to entity
            // entity.FrameworkId = viewModel.FrameworkId etc..
            db.PersonContempancies.Add(entity);  
            db.SaveChanges(); 
 
            return RedirectToAction("Index");   
        }
        ...
    }
    
