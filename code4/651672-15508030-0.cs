    var ids = Contents.
                    Select(x=> new 
                    {
                        ContentUsers = x.ContentUsers.
                            Where(t=>t.UserId==2).
                            Select(t=>t.ContentId)
                    }).
                    Where(y=>y.ContentUsers.Any())
    Contents.Where(x => ids.Contains(x.Id));
