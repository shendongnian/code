            int[] arrInt = new int[] { 1, 2, 3, 4, 5, 11, 11, 12, 13, 3, 5, 6, 11, 22, 12, 24, 5, 6, 22, 33 };
            var result = new List<List<int>>();
            List<int> sequence = null;
            foreach (var item in arrInt)
            {
                if (item < 10)
                {
                    sequence = null;
                    continue;
                }
                if (sequence == null)
                {
                    sequence = new List<int>();
                }
                sequence.Add(item);
                if (sequence.Count == 3)
                {
                    result.Add(sequence.ToList());
                    sequence = sequence.GetRange(1, 2);
                }
            }
            if (sequence.Count == 3)
            {
                result.Add(sequence);
            }
