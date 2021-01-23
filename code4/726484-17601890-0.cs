                if (file1 != null)
                {
                    var path = FileUploadHelper.UploadFile(file1, Server.MapPath(ProjectImages));
                    var image = new Image { ImageName = file1.FileName, Path = path, ContentType = file1.ContentType };
                    db.Project.Attach(project);
                    db.Images.Add(image);                    
                    project.MainImage = image;
                    context.Entry(project).State = EntityState.Modified;
                    db.SaveChanges();
                }
