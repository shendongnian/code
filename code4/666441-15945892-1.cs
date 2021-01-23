    var a = Db.Session.Query<Support>().Select(
             s => new dto {
                            Value = s.Id,
                            Count = s.CommentList.Count
                          }
                ).ToList();
