    string str1 = "A string";
    string str2 = "Some other string";
    if(String.Compare(str1,str2) < 0)
    {
       // str1 is less than str2
       Console.WriteLine("Yes");
    }
    else if(String.Compare(str1,str2) == 0)
    {
       // str1 equals str2
       Console.WriteLine("Equals");
    }
    else
    {
       // str11 is greater than str2, and String.Compare returned a value greater than 0
       Console.WriteLine("No");
    }
