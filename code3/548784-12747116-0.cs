    class Program
        {
            static void Main(string[] args)
            {
                Hashtable hashtbl = new Hashtable();
                string[,] ValueArray = new string[10, 2];
                ValueArray[0, 0] = "key1";
                ValueArray[0, 1] = "value1";
                ValueArray[1, 0] = "key2";
                ValueArray[1, 1] = "value2";
                ValueArray[2, 0] = "key3";
                ValueArray[2, 1] = "value3";
    
                for (int i = 0; i < ValueArray.GetUpperBound(0) - 1;i++)
                {
                    if (ValueArray[i, 0] == null)
                        continue;
    
                    string mykey = ValueArray[i, 0];
                    string myval = ValueArray[i, 1];
                    if (hashtbl.ContainsKey(mykey) == false)
                    {
                        hashtbl.Add(mykey, myval);
                    }
                }
    
                foreach (string key in hashtbl.Keys)
                {
                    string newVal = hashtbl[key].ToString();
    
                    Console.WriteLine("New value: " + newVal);
                }
                Console.ReadLine();
            }
        }
