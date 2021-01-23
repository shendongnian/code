    List<Model> list = (from s in context.Submissions
                        select new Model
                        {
                            Id = s.Id,
                            Name = s.Name,
                            Image = s.Image,
                            Votes = s.Votes.Count()
                        }).ToList();
