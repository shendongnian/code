    int userId = 1;
    var query = from s in db.Sections
                join r in db.Responses.Where(x => x.UserID == userId)
                       on s.SectionID equals r.Question.SectionID into g
                select new SectionModel
                {
                    ID = s.SectionID,
                    Name = s.SectionText,
                    Results = from x in g
                              orderby x.Question.DisplayOrder
                              select new QuestionResultModel
                              {
                                  Index = x.Question.DisplayOrder,
                                  Question = x.Question.QuestionText,
                                  Answer = x.AnswerValue
                              }
                };
      return View(query.ToList());
