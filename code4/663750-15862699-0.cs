    [HttpPost]
    public ActionResult Edit(int id, ChangeRequestViewModel ChangeRequestViewModel)
    {
        if (ModelState.IsValid)
        {
            var changeRequest = db.ChangeRequests
                .Include(c => c.BusinessAreas) // Important !
                .Single(c => c.ChangeRequestID == id);
            foreach (var assignedBusArea in ChangeRequestViewModel.BusinessAreas)
            {
                if (assignedBusArea.Assigned)
                {
                    if (!changeRequest.BusinessAreas
                        .Any(b => b.BusinessAreaID == assignedBusArea.BusAreaID))
                    {
                        var busArea = new BusinessArea
                        {
                            BusAreaID = assignedBusArea.BusAreaID
                        };
                        db.BusinessAreas.Attach(busArea);
                        // Attach is important to avoid duplication of the area
                        changeRequest.BusinessAreas.Add(busArea);
                    }
                    // else do nothing if the assigned area
                    // already belongs to the changeRequest
                }
                else
                {
                    var busArea = changeRequest.BusinessAreas.SingleOrDefault(
                        b => b.BusinessAreaID == assignedBusArea.BusAreaID);
                    if (busArea != null)
                        changeRequest.BusinessAreas.Remove(busArea);
                    // else do nothing if the unassigned area
                    // does not belong to the changeRequest anyway
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }            
        return View(ChangeRequestViewModel);
    }
