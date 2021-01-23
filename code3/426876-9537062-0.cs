    using(DbClassesDataContext myDb = new DbClassesDataContext(dbPath)){
    
          myDb.PatientInfos.InsertOnSubmit(patientInfo);
          myDb.ResponsibleParties.InsertOnSubmit(responsibleParty);
          myDb.SubmitChanges();
    }
