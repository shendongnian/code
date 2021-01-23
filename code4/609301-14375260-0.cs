        string[] strArr = { "Abc", "DEF", "GHI" };
        //    int i = 0;
        //    string final=string.Empty;
        //IterationStart:
        //    if (i < strArr.Length)
        //    {
        //        final += strArr[i] + ",";
        //        i++;
        //        goto IterationStart;
        //    }
        //Console.WriteLine(final);
         string str = string.Join(",", strArr);
         Console.WriteLine(str);
