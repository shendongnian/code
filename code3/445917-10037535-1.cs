        if (ImageFile.ContentLength < 1024 * 500)
                {
                    Entry newEntry = new Entry();
                    newEntry.Title = EntryTitle;
                    newEntry.EmbedURL = EntryVideo;
                    newEntry.Description = EntryDesc;
                    newEntry.UserId = currentUser.UserId;
                    db.Entries.Add(newEntry);
                    db.SaveChanges();  //this helps generate an entry id
                    string uploadsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads");
                    string userDir = Path.Combine(uploadsDir, <userid>);
                    string entryDir = Path.Combine(userDir, newEntry.EntryID );
                    if (Directory.Exists(userDir) == false)
                        Directory.CreateDirectory(userDir);
                    if (Directory.Exists(entryDir) == false)
                        Directory.CreateDirectory(entryDir);
                   string savedFileName = Path.Combine(entryDir, <entry-image>);
                   ImageFile.SaveAs(savedFileName);
                   newEntry.ImagePath = savedFileName;  //if this doesn't work pull back out this entry and adjust the ImagePath
                   db.SaveChanges();
                }
