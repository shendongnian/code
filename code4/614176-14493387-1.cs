            var chall = db.Challenges.Find(id);
            if (chall.SolvedBy == null)
            {
                chall.SolvedBy = new List<Solution>();
            }
            chall.SolvedBy.Add(new Solution {Name=User.Identity.Name});
