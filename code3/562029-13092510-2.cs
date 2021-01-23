    List<Model> list = (from s in Submissions
                        select new Model
                        {
                            Id = s.Id,
                            Name = s.Name,
                            Image = s.Image,
                            Votes = s.Votes.Count()
                        }).ToList();
