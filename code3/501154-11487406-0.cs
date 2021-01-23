        public class TestModel
        {
            public string ParentName { get; set; }
            [UIHint("HintTemplate")]
            public IEnumerable<TestChildModel> children { get; set; }
        }
    
