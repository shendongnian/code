        IEnumerable<Question> query =
            (from q in dtQuestions.AsEnumerable()
             join a in dtAnswers.AsEnumerable() on q.Field<int>("question_type_id") equals a.Field<int>("question_type_id") into Group
             select new Question()
             {
                 Id = q.Field<int>("question_type_id"),
                 SequenceNumber = q.Field<int>("sequence_no"),
                 IsChild = q.Field<bool>("isChildQuestion"),
                 EktronContentKey = q.Field<string>("ektron_content_key"),
                 Text = q.Field<string>("description"),
                 QuestionKindId = q.Field<int>("question_kind_type_id"),
                 Answers = new AnswerCollection((from a2 in Group
                                                 select new Answer()
                                                 {
                                                     Id = a2.Field<int>("answer_type_id"),
                                                     SequenceNumber = a2.Field<int>("sequence_no"),
                                                     EktronContentKey = a2.Field<string>("ektron_content_key"),
                                                     Text = a2.Field<string>("description"),
                                                     IsSelected = a2.Field<bool>("isSelected"),
                                                     ImageFileId = a2.Field<int?>("file_id"),
                                                     ChildQuestionIds =
                                                           new Collection<int>((from r in dtAnswerChildQuestions.AsEnumerable()
                                                                                where r.Field<int>("answer_type_id") == a2.Field<int>("answer_type_id")
                                                                                select r.Field<int>("question_type_id")).ToList())
                                                 }))
             }
          );
        foreach (var question in query)
        {
            question.SelectedAnswerId = question.QuestionKindId == 1 ?
                                        (from Answer a3 in question.Answers
                                         where a3.IsSelected == true
                                         select a3.Id).SingleOrDefault() :
                                        0;
            question.SelectedAnswerIds = question.QuestionKindId == 2 ?
                                         new Collection<int>((from Answer a4 in question.Answers
                                                              where a4.IsSelected == true
                                                              select a4.Id).ToList()) :
                                         new Collection<int>();
            this.Add(question);
        }
