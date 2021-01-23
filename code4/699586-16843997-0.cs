    public ActionResult GetOwners(int id = 0)
            {
                Departments department = db.Department.Find(id);
    
                AD_DepartmentProfile dp = new ActiveDirectory().GetDepartmentInfo(department.name, department.owner);
    
                return this.Json(dp, JsonRequestBehavior.AllowGet);
            }
