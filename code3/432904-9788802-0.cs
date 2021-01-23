        Employee entity = GetEntityById(id);
        EmployeeEditViewModel model = new EmployeeEditViewModel();
        Mapper.Map(source, destination);            
        return View("Edit", model);
    }
    [HttpPost]
    public virtual ActionResult Edit(EmployeeEditViewModel model)
    { 
        if (ModelState.IsValid)
        {
            Employee entity = GetEntityById(model.Id);
            entity = Mapper.Map(model, entity);               
            EntitiesRepository.Save(entity);
            return GetIndexViewActionFromEdit(model);
        }           
        return View("Edit", model);
    }
