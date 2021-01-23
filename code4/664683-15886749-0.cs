    var document = Mapper.Map(model, _documentRepository.Find(model.ID));
    document.DateModified = DateTime.Now;
    // Set the new associatins with PatientTypes
    document.PatientTypes.Clear();
    foreach(var pt in model.PatientTypeList.Select(id => new PatientType{Id = id}))
    {
        document.PatientTypes.Add(pt);
    }
    
    _documentRepository.InsertOrUpdate(document);
    _documentRepository.Save();
