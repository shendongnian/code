    var s = "ThisCourseIDMoreXYeahY";
    s = string.Join(
            string.Empty, 
            s.Select((x,i) => (
                 char.IsUpper(x) && i>0 && 
                 ( char.IsLower(s[i-1]) || (i<s.Count()-1 && char.IsLower(s[i+1])) )
            ) ? " " + x : x.ToString()));
    Console.WriteLine(s);
