    DateTime date = DateTime.ParseExact(line.Substring(0, 10), "MM\\/dd\\/yyyy");
    string[] nums = new string[6];
    nums[0] = line.Substring(12, 2).Trim();
    nums[1] = line.Substring(16, 2).Trim();
    etc...
