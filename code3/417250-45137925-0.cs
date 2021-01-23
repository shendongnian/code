    for (int x = 0; x < grid.Length; x++)
            {
                var intCount = grid[x].Select((a, b) => new {Value = a, Index = b})
                    .GroupBy(y => y.Value)
                    .Where(y => y.Count() > 1).Select(item => item.Key).ToArray();
                if (intCount.Count() > 1)
                    return false;
            }
