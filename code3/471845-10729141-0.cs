         public JsonResult MvrSummary(int MvrId)
            {
           MedicalVarianceEntities DbCtx = new MedicalVarianceEntities();
                var data = from entity in DbCtx.Mvrs
                              select new
                              {
                                  Prop1 = entity.PKMvrId,
                                  
                                  ChildProp = entity.MvrEmployees.Select(x=>x.ODSEmpNumber),
                                  GrandChildProp = entity.MvrEmployees.Select(x=>x.MvrEmployeesStorageErrors.Select(y=>y.MvrEmployeesStorageErrorsId))
                              };
     return Json(data, JsonRequestBehavior.AllowGet);
    }
