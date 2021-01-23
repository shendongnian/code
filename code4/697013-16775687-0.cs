        private static string[]  ProcessInput(string input, int length)
        {
            // handle empty or null input
            if (string.IsNullOrEmpty(input))
                return null;
            var items = input.Split(':').ToList();
            // adding empty strings untill given length
            while (items.Count <= length)
            {
                items.Add(string.Empty);
            }
            //even split return more items than length return expected length
            return items.Take(length).ToArray();
        }
