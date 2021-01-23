    [HttpPost]
    public ActionResult Create(DomainEntity i_EntityToCreate, int? ParentEntityID)
    {
      using (var db = new CamelotShiftManagementEntities())
      {
        i_EntityToCreate.ParentEntityId = ParentEntityID;
        i_EntityToCreate.EntityTypeID = 1;
        db.DomainEntities.Add(i_EntityToCreate);
        db.SaveChanges();
      }
 
      return RedirectToAction("Index");
 
    }
