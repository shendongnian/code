        var student = new Student() { Name = "John", Age = 22, ID = 3254, Email = "John123@yahoo.com", Country = "United StateS" };
        using (FileStream fsw = new FileStream("SomeFile.txt", FileMode.Append, FileAccess.Write))
        {
            using (StreamWriter sw = new StreamWriter(fsw))
            {
                sw.WriteLine(student.FormatForOutput());
            }
        }
