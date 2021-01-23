    using (DataContext dtx = new DataContext()) {
    
    			Note note = new Note();
    
    			dtx.Notes.Add(note);
    
    			Company company = dtx.Companies.FirstOrDefault((System.Object obj) => obj.ServerId == 1);
    
    			note.Server = company;
    
    			dtx.SaveChanges();
    
    		}
