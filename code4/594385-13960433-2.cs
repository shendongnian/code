    int userId = 1;
    var query = (from s in db.Sections
                 join r in db.Responses.Where(x => x.UserID == userId)
                        on s.SectionID equals r.Question.SectionID into g
                 select new
                 {
                     s.SectionID,
                     s.SectionText,
                     Results = (from x in g
                                orderby x.Question.DisplayOrder
                                select new
                                {
                                    x.Question.DisplayOrder,
                                    x.Question.QuestionText,
                                    x.AnswerValue
                                }).ToList()
                 }).ToList();
