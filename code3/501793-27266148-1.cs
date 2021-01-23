             BugTracker_DataHelper bugedit = new BugTracker_DataHelper();           
             bugedit.ProjectId =Convert.ToString(projectId);
             var edit = EditList();
             return View(edit);      
        }
