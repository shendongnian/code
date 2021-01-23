    Service service = repository.GetService(model.selectedService);
    incidentToAdd.Service = service;
    db.Entry(service).State = EntityState.Unchanged;
            
    Category category = repository.GetCategory(model.selectedCategory);
    incidentToAdd.Category = category;
    db.Entry(category).State = EntityState.Unchanged;
    HelpDeskMember allocatedTo = repository.GetHelpDeskMember(model.selectedAllocatedTo);
    incidentToAdd.AllocatedTo = allocatedTo;
    db.Entry(allocatedTo).State = EntityState.Unchanged;
