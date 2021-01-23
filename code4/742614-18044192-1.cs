     public class Question
        {
            public string Id { get; set; }
            public string Text { get; set; }
            public string Option1 { get; set; }
            public string Option2 { get; set; }
            public string Option3 { get; set; }
            public string Option4 { get; set; }
            public string AnswerOption { get; set; }
            public int Marks { get; set; }
        }
        public IEnumerable<Question> GetQuestions(string topicId, int marks)
        {
            string sql = "select QID,Question,Opt1,Opt2,Opt3,Opt4,AnsOp,Marks from Questions where TopicID IN(" +
                         topicId + ") and Marks=" + marks.ToString();
            var cmd = new OleDbCommand(sql, new OleDbConnection(""));
            var rs = cmd.ExecuteReader();
            if (rs != null)
            {
                while (rs.Read())
                {
                    yield return
                        new Question
                            {
                                Id = rs[0].ToString(),
                                Text = rs[1].ToString(),
                                Option1 = rs[2].ToString(),
                                Option2 = rs[3].ToString(),
                                Option3 = rs[4].ToString(),
                                Option4 = rs[5].ToString(),
                                AnswerOption = rs[6].ToString(),
                                Marks = marks
                            };
                }
            }
        }
        public void Foo()
        {
            var totQsn = Convert.ToInt16(conf[0]); // isn't this just the sum of everything else?
            var mark1qsn = Convert.ToInt16(conf[3]); //this variable contains number of question to be display of mark 1
            var mark2qsn = Convert.ToInt16(conf[4]);
            var mark3Qsn = Convert.ToInt16(conf[5]);
            var mark4Qsn = Convert.ToInt16(conf[6]);
            var mark1questionSet = GetQuestions(topicId, 1).ToList();
            var mark2questionSet = GetQuestions(topicId, 2).ToList();
            // etc
            var finalQuestions = new List<Question>();
            for (int i = 0; i < mark1qsn; i++)
            {
                var setIndex = _random.Next(mark1questionSet.Count);
                finalQuestions.Add(mark1questionSet[setIndex]);
                mark1questionSet.RemoveAt(setIndex);
            }
            for (int i = 0; i < mark2qsn; i++)
            {
                var setIndex = _random.Next(mark2questionSet.Count);
                finalQuestions.Add(mark2questionSet[setIndex]);
                mark2questionSet.RemoveAt(setIndex);
            }
            // etc - put this into a method or something
        }
