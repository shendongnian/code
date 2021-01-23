    List<Model> list = (from s in Submissions
            select new Model
            {
                Id = s.Id,
                Name = s.Name,
                Image = s.Image,
                Votes = (from v in Votes
                         where v.Fk_id == s.Id
                         group v by v.Fk_id into g
                         select g.Count()).FirstOrDefault()
            }).ToList();
