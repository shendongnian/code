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
