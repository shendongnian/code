    Console.WriteLine("enter id of student to input marks to:");
    string id = Console.ReadLine();
    var marks = new Dictionary<int, List<Mark>>();
    if (UserExists(id))
    {
        Console.WriteLine("mark for subject1:");        
        string s1 = Console.ReadLine();
        Console.WriteLine("mark for subject2:");        
        string s2 = Console.ReadLine();
        var list = new List<Mark>();
        list.Add(new Mark { Subject = SubjectEnum.Subject1, Value = Convert.ToDecimal(s1), });
        list.Add(new Mark { Subject = SubjectEnum.Subject2, Value = Convert.ToDecimal(s2), });
        marks.Add(Convert.ToInt32(id), list)
    }
    else
    {
        Console.WriteLine("id not found");
    }
