    public static void GroupString(string str) 
        {
            if (str.Length == 1)
                Console.WriteLine(str[0] + " 1");
            else
            {
                Console.WriteLine(str[0] +  " "+ str.Count(c => c == str[0]));
                GroupString(str.Replace(str[0].ToString(),""));
            }
        } 
