    public List<QuestionInfo> GetMotherActualDayCareAge(string var1, string var2)
        {
            List<QuestionInfo> mumsHabits;
            var answers = Answers.GetAnswers;
            string answerValue = string.Empty;
            var oneA = from a in answers
                       where a.Questionid == var1
                       select new QuestionInfo { questionId = a.Questionid, userId = a.UserId };
            var oneB = from a in answers
                       where a.Questionid == var2
                       select new QuestionInfo { questionId = a.Questionid, userId = a.UserId };
            var temp = oneA.Union(oneB).ToList();
            mumsHabits = temp.Intersect(mothers, new UserIdEqualityComparer()).ToList();
            return mumsHabits;
        }
