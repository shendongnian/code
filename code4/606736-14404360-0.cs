    class StorageBox
        {
            bool[] box = new bool[] { false, false, false, false, false, false };
    
            public void Addtobox(int number)
            {
                if (number<7 && number >0)
                    box[number - 1] = true;
            }
    
            public string WhatIsinBox()
            {
                string result = "";
    
                for (int i = 0; i <= 5; i++)
                {
                    if (box[i])
                        result = result + (i+1).ToString() + ",";
    
                }
                return result.Substring(0, result.Length - 1);
            }
    
            public void ClearBox()
            {
                box = new bool[] { false, false, false, false, false, false };
            }
        }
    
    
        class ExecuteSample
        {
            static void Main(string[] args)
            {
                var box = new StorageBox();
    
                box.Addtobox(5);
                box.Addtobox(3);
                box.Addtobox(4);
    
                Console.WriteLine(box.WhatIsinBox());
    
                Console.Read();
            }
    
    
        }
