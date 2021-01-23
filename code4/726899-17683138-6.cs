            // This is your transmitter count
            int groups = 4; 
            // These are your SMS's
            List<int> values = new List<int>(){1,2,3,4,5,6,7,8,9};
            //Calculate group size
            int extra;
            int groupSize = Math.DivRem(values.Count, groups, out extra);
            var result = new List<IEnumerable<int>>();
            while (values.Any())
            {
                int newSize = groupSize;
                if (extra > 0)
                {
                    // Account for extras
                    newSize++;
                    extra--;
                }
                result.Add(values.Take(newSize));
                values = values.Skip(newSize).ToList();
            }
            return result;
