    List<SopFolder> sopfolderlist = ConvertTree(items.First());
    
            SopFolder sopfolder = sopfolderlist[0];
    
            if (ModelState.IsValid)
            {
                SopFolder startFolder = new SopFolder { Id = sopfolder.Id };
    
                //db.SopFolders.Attach(startFolder);
               // db.SopFolders.Attach(sopfolder);
    
                startFolder.Name = sopfolder.Name;
                startFolder.LastUpdated = sopfolder.LastUpdated;
                startFolder.SopFields = sopfolder.SopFields;
                startFolder.SopFolderChildrens = sopfolder.SopFolderChildrens;
    
                foreach (var child in sopfolder.SopFolderChildrens)
                {
                   db.SopFolders.CurrentValues.SetValues(child);
                   db.SaveChanges();
                }
    
                startFolder.Status = sopfolder.Status;
                db.Entry(startFolder).State = EntityState.Modified;
                db.SaveChanges();
                return Content("true");
            }
