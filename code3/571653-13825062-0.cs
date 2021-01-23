    [HttpPost]
    public ActionResult Create([Bind(Exclude = "interventionID")]tIntervention tintervention, int id, int? personid)
    {
        tintervention.householdID = id;
                     
        if (ModelState.IsValid)
        {
            db.tInterventions.Add(tintervention);
            if (personid.HasValue)
            {
                int personID = personid.Value;
                var q = (
                            from p in db.tPersons
                            where (p.personID == personID)
                            select p.personID
                            );
                personID = q.FirstOrDefault();
                tPerson tperson = db.tPersons.Find(personID);
                tintervention.tPersons.Add(tperson);
            }
            db.SaveChanges();
       
            return RedirectToAction("Index");
        }
        return View(tintervention);
    }
