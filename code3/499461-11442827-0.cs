       [HttpPost]
       public ActionResult Edit(CompanyInput input)
       {
          if (ModelState.IsValid)
          {
              return View("Success");
          }
          input.CompanyName = string.Empty;
          return View(input);
       }
