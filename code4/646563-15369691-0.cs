    public ActionResult Delete(string departmentId)
        {
            try
            {
                new DepartmentManager().DeleteDepartment(departmentId);
            }
            catch (System.Exception exception)
            {
                ModelState.AddModelError("Error", "Unable to delete department. Try again,      and if the problem persists see your system administrator.");
                //return RedirectToAction("Index", "Department");
    YOU SHOULD ADD MESSAGE TO VIEWDATA HERE, OR RETURN SAME VIEW(make delete POST action also)
    
            }
        return RedirectToAction("Index", "Department");
    }
