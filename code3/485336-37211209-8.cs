    using System;
    
    namespace MyMessage
    {
        [Serializable]
        public sealed class MyMessage
        {
            public TimeSpan LifeInterval { get; set; }
    
            public DateTime BornPoint { get; set; }
    
            public string Text { get; set; }
        }
    }
