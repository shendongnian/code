    DateTime beginningOfWeek = DateTime.Now.BeginningOfWeek();
    DateTime twoWeeksAgo = beginningOfWeek.AddDays(-14);
    DateTime endOfLastWeek = beginningOfWeek.AddMilliseconds(-1);
    var query = from s in scores
                where s.Date >= twoWeeksAgo && s.Date <= endOfLastWeek
                orderby s.Date
                group s by new { s.User, s.Subject } into g
                select new
                    {
                        User = g.Key.User,
                        Subject = g.Key.Subject,
                        Date = g.Last().Date,
                        Diff = g.Last().Score - g.First().Score
                    };
