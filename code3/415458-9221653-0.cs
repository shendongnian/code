    static ArrayList list;
        static void Main(string[] args)
        {
            string str = "1,4-90,292,123";
            string[] arr = str.Split(',');
            list = new ArrayList();
            for (int i = 0; i < arr.Length; i++)
            {
                string tmp = arr[i];
                if (tmp.IndexOf('-') != -1)
                {
                    Range(tmp);
                }
                else list.Add(int.Parse(tmp));
            }
            list.Sort();
            object[] intResult = list.ToArray();
            //print the final result
            for (int i = 0; i < intResult.Length; i++)
            {
                Console.WriteLine(intResult[i].ToString());
            }
            Console.Read();
        }
        static void Range(string range)
        {
            string[] tmpArr = range.Split('-');
            int stInt = int.Parse(tmpArr[0]);
            int edInt = int.Parse(tmpArr[1]);
            int[] intArr = new int[(edInt - stInt) + 1];
            for (int i = 0; stInt <= edInt; i++)
            {
                list.Add(stInt++);
            }
        }
