    String[] file1Lines = File.ReadAllLines(path1);
    String[] file2Lines = File.ReadAllLines(path2);
    for (int i = 0; i < Math.Max(file1Lines.Length, file2Lines.Length); i++)
    {
        if (i > file1Lines.Length)
            /* missing from file 1 */ ;
        else if (i > file2Lines.Length)
            /* missing from file 2); */ ;
        else if (file1Lines[i].Equals(file2Lines[i]))
            /* lines are equal */ ;
        else
            /* lines are different */ ;
    }
