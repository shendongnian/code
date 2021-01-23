    using System;
    using System.Collections.Generic;
    class csWordSimilarity : IEnumerable<int> {
        public int irColumn1 = 0;
        public int irColumn2 = 0;
        public int irColumn3 = 0;
        public int irColumn4 = 0;
        public int irColumn5 = 0;
        public IEnumerator<int> GetEnumerator() {
            return (new List<int>() { 
                irColumn1, irColumn2, irColumn3, irColumn4, irColumn5 
            }).GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
