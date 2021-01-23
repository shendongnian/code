    public static int? FirstFree(Dictionary<int, Guid> dict, int min, int max)
        {
            if (max <= min)
                throw new Exception($"Specified range is invalid (must be max > min)");
            if (max - min + 1 == dict.Count)
                //no space left
                return null;
            return Enumerable.Range(min, max).Except(dict.Keys).First();
        }
