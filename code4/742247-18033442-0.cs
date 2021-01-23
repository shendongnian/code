    [HttpPost]
            public ActionResult GetRegInfo(string reg)
            {
                var gri = new GetRegInfo(reg);
                TempData["GetRegInfo"] = gri;
                
                Action<object> action = (object obj) => gri.Start();
                var t1 = new Task(action, "GetRegInfo");   
                t1.Start();
    
                return View("bilforsakring");
            }
