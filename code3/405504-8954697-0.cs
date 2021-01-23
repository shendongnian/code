     public viewmodelclass d (int number)
            { var q_t =  new viewmodelclass()
            {
                    Message = "This question current;y have" + number,
                    Total = number,
                    Questions = from question123 in entities1.Questions
                                       where question123.QuestionID >= number
                                       select question123
                };
         return q_t;}
