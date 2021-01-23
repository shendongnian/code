    public class ViaggioController : Controller
    {
    public ActionResult Create() 
    {
        var emptyModel = new MyViewModel();
        return RedirectToAction("Edit", new { mm = emptyModel });
    }
    public ActionResult Edit(MyViewModel mm) 
    {    
        return View(mm);
    }
    
    public ActionResult Review(MyViewModel mm) 
    {
        if (ModelState.IsValid)
        {
            return View(mm);
        } 
        else 
            return RedirectToAction("Create");
    }
    }
