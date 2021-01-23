        private void WriteLine(String text)
        {
            textBox1.Text += text + Environment.NewLine;
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            List<TestClass> list = new List<TestClass>();
    
            list.Add(new TestClass { Title = "101 unanswered questions", Description = "There are many questions which go unanswered, here are our top 1001" });
            list.Add(new TestClass { Title = "Best of lifes questions", Description = "Many of lifes questions answered" });
            list.Add(new TestClass { Title = "Top 10 smart answers", Description = "Top 10 smart answers for common interview questions" });
    
            var results =
                list.Where(x => x.Description.Contains("answered questions") | x.Title.Contains("answered questions"));
            foreach (TestClass res in results)
            {
                WriteLine(String.Format("Title: {0}, Desc: {1}", res.Title, res.Description));
            }
        }
    }
    
    public class TestClass
    {
        public String Title;
        public String Description;
        public String Contents;
    
        public TestClass()
        {
            Title = "";
            Description = "";
            Contents = "";
        }
    }
