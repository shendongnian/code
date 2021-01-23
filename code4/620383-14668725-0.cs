            var LR = new []
                         {
                             new {start = 88, end = 96},
                             new {start = 93, end = 100}
                         };
            var _fts = new List<int>();
            for (int i = 0; i < LR.Length; i++)
            {
                _fts.AddRange(Enumerable.Range(LR[i].start, LR[i].end - LR[i].start + 1));
            }
            Console.WriteLine(String.Join(" ", _fts));
