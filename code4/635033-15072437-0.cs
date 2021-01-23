        private List<string> Process(IEnumerable<string> input)
        {
            List<string> data = new List<string>();
            int preExpandCount = 0, offset = 0;
            foreach (string inputItem in input)
            {
                List<string> splitItems = inputItem.Split(',').ToList();
                if (data.Count > 0)
                    preExpandCount = ExpandList(data, splitItems.Count - 1);
                offset = 0;
                foreach (string splitItem in splitItems)
                {
                    if (preExpandCount == 0)
                        data.Add(splitItem);
                    else
                    {
                        for (int i = 0; i < preExpandCount; i++)
                            data[i + offset] = String.Format("{0},{1}", data[i + offset], splitItem);
                        offset += preExpandCount;
                    }
                }
            }
            return data.OrderBy(e => e).ToList();
        }
        private int ExpandList(List<string> existing, int count)
        {
            int existingCount = existing.Count;
            for (int i = 0; i < count; i++)
                existing.AddRange(existing.Take(existingCount).ToList());
            return existingCount;
        }
