    foreach (string applicationName in applicationNames)
            {
                var app = new Application 
                    { 
                        Name = applicationName, 
                        ModifiedDate = DateTime.Now 
                    });
                _uow.Applications.Add(app);
                    foreach (string testAccountName in testAccountNames)
                    {
                       new TestAccount 
                       { 
                           Application = app ,
                           Name = applicationName, 
                           ModifiedDate = DateTime.Now 
                       });
                    }
            }
