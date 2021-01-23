    var s = "ThisCourseID";
    for (var i = 1; i < s.Length; i++)
    {
        if (char.IsLower(s[i - 1]) && char.IsUpper(s[i]))
        {
            s = s.Insert(i, " ");
        }
    }
    Console.WriteLine(s); // "This Course ID"
