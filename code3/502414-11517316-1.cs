    List<List<int>> numbers = new List<List<int>>();
    foreach (string line in File.ReadAllLines(""))
    {
        var list = new List<int>();
        foreach (string s in line.Split(new[]{',', ' '}, StringSplitOptions.RemoveEmptyEntries))
        {
            int i;
            if(int.TryParse(s, out i))
            {
                list.Add(i);
            }
        }
        numbers.Add(list);
    }
    int special = numbers[3][4];
