    var s = "ThisCourseIDSomething";
    for (var i = 1; i < s.Length - 1; i++)
    {
        if (char.IsLower(s[i - 1]) && char.IsUpper(s[i]) ||
            s[i - 1] != ' ' && char.IsUpper(s[i]) && char.IsLower(s[i + 1]))
        {
            s = s.Insert(i, " ");
        }
    }
    Console.WriteLine(s); // This Course ID Something
