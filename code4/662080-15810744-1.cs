    SomeObject a = db.SomeObjects.Where(x => x.Id == someobjectid)
                          .Select(
                              x =>
                              new
                                  {
                                      someObject = x,
                                      task = x.Tasks.Where(task => task.IsDeleted == false)
                                                    .OrderBy(task => whatever)
                                  });
     return a.FirstOrDefault().someObject;
                    
