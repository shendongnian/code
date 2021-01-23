    public class RebateLineController : BaseController
    {
       public ActionResult Create(int id)
        {
          return View();
        } 
    //
    // POST: /RebateLine/Create
    [HttpPost]
    public ActionResult Create(int id,RebateLine rebateline)
    {
        if (ModelState.IsValid)
        {
            UnitOfWork.RebateLineRepository.Insert(rebateline);
            UnitOfWork.Save();
            return RedirectToAction("Index");  
        }
        return View(rebateline);
    }
    ...
    }
