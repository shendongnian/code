            [HttpGet]
            public ActionResult Edit(int id = -1)
            {
                var employee = new Employee(); // here you should to get user data for editing instead of creating empty model
    
                if (employee == null)
                {
                    return HttpNotFound();
                }
    
                return View(employee);
            }
