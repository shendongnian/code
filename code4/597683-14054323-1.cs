    foreach (var versionDetail in versions)
    {
        bool isNew = false;
        var detail = versionDetail;
        var dbVersionentity = _productVersionEntityRepository.FirstOrDefault(x => x.Id == detail.Id);
        // not found in database
        if(dbVersionentity == null)
        {
            isNew = true;
            
            // create entity here
            dbVersionentity = new .....; 
            
			// you don't need to do this if id is auto-generated, 
			// i.e. Identity column in SQL Server
			dbVersionentity.Id = GetNextTableId("vProductVersion");
        }
        
        dbVersionentity.Name = detail.Name;
        dbVersionentity.Code = detail.Name;
        
        
        if (isNew)
        {
            _productVersionEntityRepository.Insert(dbVersionentity);
        }
        else
        {
            _productVersionEntityRepository.Update(dbVersionentity);
        }
    }
