    protected override void Seed(MyContext context)
            {
                //  This method will be called after migrating to the latest version.
    
                //Add menu items and pages
                if (!context.Menu.Any() && !context.Page.Any())
                {
                    context.Menu.AddOrUpdate(
                        new Menu()
                        {
                            Id = Guid.NewGuid(),
                            Name = "MainMenu",
                            Description = "Some menu",
                            IsDeleted = false,
                            IsPublished = true,
                            PublishStart = DateTime.Now,
                            LastModified = DateTime.Now,
                            PublishEnd = null,
                            MenuItems = new List<MenuItem>()
                            {
                                new MenuItem()
                                {
                                    Id = Guid.NewGuid(),
                                    IsDeleted = false,
                                    IsPublished = true,
                                    PublishStart = DateTime.Now,
                                    LastModified = DateTime.Now,
                                    PublishEnd = null,
                                    Name = "Some menuitem",
                                    Page = new Page()
                                    {
                                        Id = Guid.NewGuid(),
                                        ActionName = "Some Action",
                                        ControllerName = "SomeController",
                                        IsPublished = true,
                                        IsDeleted = false,
                                        PublishStart = DateTime.Now,
                                        LastModified = DateTime.Now,
                                        PublishEnd = null,
                                        Title = "Some Page"
                                    }
                                },
                                new MenuItem()
                                {
                                    Id = Guid.NewGuid(),
                                    IsDeleted = false,
                                    IsPublished = true,
                                    PublishStart = DateTime.Now,
                                    LastModified = DateTime.Now,
                                    PublishEnd = null,
                                    Name = "Some MenuItem",
                                    Page = new Page()
                                    {
                                        Id = Guid.NewGuid(),
                                        ActionName = "Some Action",
                                        ControllerName = "SomeController",
                                        IsPublished = true,
                                        IsDeleted = false,
                                        PublishStart = DateTime.Now,
                                        LastModified = DateTime.Now,
                                        PublishEnd = null,
                                        Title = "Some Page"
                                    }
                                }
                            }
                        });
                }
    
                if (!context.ComponentType.Any())
                {
                    context.ComponentType.AddOrUpdate(new ComponentType()
                    {
                        Id = Guid.NewGuid(),
                        IsDeleted = false,
                        IsPublished = true,
                        LastModified = DateTime.Now,
                        Name = "MyComponent",
                        PublishEnd = null,
                        PublishStart = DateTime.Now
                    });
                }
    
    
                try
                {
                    // Your code...
                    // Could also be before try if you know the exception occurs in SaveChanges
    
                    context.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    //foreach (var eve in e.EntityValidationErrors)
                    //{
                    //    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    //        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    //    foreach (var ve in eve.ValidationErrors)
                    //    {
                    //        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                    //            ve.PropertyName, ve.ErrorMessage);
                    //    }
                    //}
                    //throw;
    
                    var outputLines = new List<string>();
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        outputLines.Add(string.Format(
                            "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:",
                            DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                        foreach (var ve in eve.ValidationErrors)
                        {
                            outputLines.Add(string.Format(
                                "- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage));
                        }
                    }
                    System.IO.File.AppendAllLines(@"c:\temp\errors.txt", outputLines);
                    throw;
                }
            }
