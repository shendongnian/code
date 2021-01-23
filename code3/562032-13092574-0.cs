    List<Model> = (from p in Submissions 
                  select new Model
                  {
                     Name = p.Name,
                     Image = p.Image,
                     Votes = p.Votes.Count() 
                  }).ToList();
