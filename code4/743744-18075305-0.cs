    string str = "1,2,3,4,i am some text,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20";
    int counter = 0;
    int idx = 0;
    List<string> foo = new List<string>();
    foreach (char c in str.ToArray())
    {
         idx++;
         if (c == ',')
         {
              counter++;
         }
         if (counter == 4)
         {
              string x = str.Substring(idx);
              foo.Add(str.Substring(idx, x.IndexOf(',')));
              counter = 0;
         }
    }
    foreach(string s in foo)
    {
         Console.WriteLine(s);
    }
    Console.Read();
