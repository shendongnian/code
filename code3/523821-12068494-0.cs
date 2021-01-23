    string fileData = System.IO.File.ReadAllText(@"C:\1\1.txt");  
            string[] words = fileData.Split(' ');  
            List<int> integers = new List<int>();  
            foreach (string word in words)  
            {  
                try  
                {  
                    int integer = int.Parse(word);  
                    if(integer > 500)  
                        integers.Add(integer);  
                }  
                catch (Exception)  
                {  
                    //some code maybe 
                }  
            }  
            foreach (int integer in integers)  
            {  
                MessageBox.Show(integer.ToString());  
            }  
