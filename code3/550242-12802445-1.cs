              Public object GetNewSubject( string Id )     
             {     
     
                 SubjectDB subjectdb = new SubjectDB();     
                 DBEntites db = new DBEntities();     
     
                 var subjectxx = db.SubjectDB.FirstOrDefault(x => x.SubjectId == Id);     
                 var addressxx = db.AddressDB.FirstOrDefault(x => x.SubjectId == Id);     
                 .     
                 .     
                 subjectdb.SubjectId = subjectxx.Subjectid;
                 subjectdb.Name = subjectxx.Name;     
                 .     
                 .
                 // Put LIST data into LIST          
                 subjectdb.Address.Add(addressxx);     
                 .     
                 .     
                 return(subjectdb);     
              }
