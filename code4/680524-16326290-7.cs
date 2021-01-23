    using System.Collections.Generic;
    namespace RazorListTest.Models
    {
        public class AnswerDisplayItem
        {
            public bool IsMissing { get; set; }
            public string Text { get; set; }
            public string Value { get; set; }
            public string Id { get; set; }
        }
        public class AnswerScheme
        {
            public List<AnswerDisplayItem> Answers { get; set; }
            public string Id { get; set; }
    
            public AnswerScheme()
            {
                Answers = new List<AnswerDisplayItem>();
            }
        }
    }
