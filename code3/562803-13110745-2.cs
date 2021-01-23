    public static List<int[]> FindTheHighestArrays(List<int[]> lst)
    {
        List<KeyValuePair<int[], int>> temp = new List<KeyValuePair<int[], int>>();
        List<int[]> retList = lst;
        lst.Sort((x, y) => x.Length.CompareTo(y.Length));
        int highestLenght = lst[lst.Count - 1].Length;
        for (int i = 0; i < highestLenght; i++)
        {
            temp.Clear();
            foreach (var item in retList)
            {
                if (item.Length <= i)
                    continue;
                temp.Add(new KeyValuePair<int[], int>(item, item[i]));
            }
            temp.Sort((x, y) => x.Value.CompareTo(y.Value));
            retList.Clear();
            retList.AddRange(temp.FindAll(kvp => kvp.Value == temp[temp.Count - 1].Value).ConvertAll(f => f.Key));
            if (retList.Count == 1)
                return retList;
        }
        return retList;
    }
