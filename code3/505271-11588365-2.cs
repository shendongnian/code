            string text = "present present present presenting presentation do  do doing";
            var ws = text.Split(' ');
            //Passing the words into the list:
            words = (from w in ws
                     group w by w into wsGroups
                     select new KeyValuePair<string, int>(
                         wsGroups.Key, ws.Count()
                         )
                     ).ToList<KeyValuePair<string, int>>();
            //Ordering:
            words.OrderBy(w => w.Value);
            //Stemming the words:
            words = (from w in words
                     select new KeyValuePair<string, int>
                         (
                             stemword(w.Key),
                             w.Value
                         )).ToList<KeyValuePair<string, int>>();
            //Sorting and put into Dictionary:
            var wordsRef = (from w in words
                            group w by w.Key into groups
                            select new
                            {
                                count = groups.Count(),
                                word = groups.Key
                            }).ToDictionary(w => w.word, w => w.count);
