    string s = "NEW ITEM:1_BELT:3_JEANS:1_BELT:1_SUIT 3 PCS:1_SHOES:1";
    var array = s.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
    StringBuilder sb = new StringBuilder();
    foreach (var item in array)
    {
        if (Char.IsDigit(item[0]))
        {
            sb.Append(":" + item[0]);
        }
    }
    
    Console.WriteLine(sb); //:1:3:1:1:1:1
