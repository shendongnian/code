    someList = new List<Pupil>();
    
    someList.Add(new Pupil
            {
                Name = "Simon",
                Result = 100,
                Grade = 100.00,
                ExtensionWork = true,
                TakenTest = true
    
            });
    
            foreach (Pupil pupil in app.PupilList)
            {
                someList.Add(pupil);
    
            }
        
