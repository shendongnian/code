        static List<string> Put(char s1, string list)
        {
            List<string> str =new List<string>();
            
            for (int i = 0; i < list.Length+1; i++)
            {
                string s = list.Substring(0, i) + s1.ToString() + list.Substring(i);
                str.Add(s);
            }
            return str;
        }
        static List<string> Permute(string list,int x)
        {
            List<string> Result = new List<string>();
            if (list.Length == 1)
            {
                Result.Add(list[0].ToString());
                return Result;
            }
            else
            {
                
                char first = list[0];
                list = list.Substring(x+1);
                List<string> part = Permute(list,0);
                foreach (string str in part)
                {
                      List<string> hasBeenPlaced = Put(first, str);
                      foreach (string str2 in hasBeenPlaced)
                      {
                            Result.Add(str2);
                      }
                }
                
            }
        
            return Result;
        }
        static void Main(string[] args)
        {
            List<string> per = Permute("abc",0);
            for (int i = 0; i < per.Count; i++)
            {
                Console.WriteLine(per[i]);
            }
            Console.ReadKey();
        }
