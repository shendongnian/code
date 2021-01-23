    public ActionResult Edit(int projectId)
    {
         BugTracker_DataHelper bugedit = new BugTracker_DataHelper();           
         var edit = EditList();
         bugedit.ProjectId =Convert.ToString(projectId);
         return View(edit);      
    }
