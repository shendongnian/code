        public int WordCount(string s) {
            const int DONE = -1;
            var wordCount = 0;
            var index = 0;
            var str = s.Trim();
            while (index != DONE) {
                wordCount++;
                index = str.IndexOf(" ", index + 1);
            }
            return wordCount;
        }
