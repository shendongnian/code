    List<string> list = new List<string>();
    list.Add("student");
    list.Add("students");
    list.Add("Student");
    list.Add("Students");
    list = list.Where(r => char.IsLower(r[0])).OrderBy(r => r)
          .Concat(list.Where(r => char.IsUpper(r[0])).OrderBy(r => r)).ToList();
    for (int i = 0; i < list.Count; i++)
        Console.WriteLine(list[i]);
