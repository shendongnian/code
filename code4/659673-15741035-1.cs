         [HttpPost]
         public JsonResult EditEmployee(Models.Employee employee) 
         {
             try
             {
                 if (ModelState.IsValid)
                 {
                     using (emsCtx)
                     {
                         var employeeResults = (from q in emsCtx.Employees
                                                where q.Id == employee.Id
                                                 select q
                                                ).FirstOrDefault();        
                         if(employeeResults!=null)
                         {             
                               employeeResults.Column1 = employee.Column1; 
                               employeeResults.Column2 = employee.Column2; 
                               employeeResults.Column3 = employee.Column3; 
                               employeeResults.Column4 = employee.Column4; 
                         }
                         emsCtx.SaveChanges();
                     }
                     return Json();
                 }
