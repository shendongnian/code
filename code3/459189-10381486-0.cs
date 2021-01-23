    var questions = _context.Questions
                .Where(q => q.Level.Level == level)
                .Select(q => new QuestionViewModel
                {
                    Text = q.Text,
                    Id = q.Id,
                    IsMultiSelected = q.IsMultiSelected,
                    AnswerViewModels = q.Answers
                                           .Select(
                                               a => new AnswerViewModel
                                                        {
                                                            Checked = false,
                                                            Text = a.Text,
                                                            Id = a.Id
                                                        })
                }).AsEnumerable().Select(x => new QuestionViewModel
                  {
                       Text = x.Text,
                       Id = x.Id,
                       IsMultiSelected = x.IsMultiSelected,
                       AnswerViewModels = x.Answers.ToList()
                   });
            return questions.ToList();
