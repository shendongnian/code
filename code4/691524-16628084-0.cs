               System.IO.StreamReader file = new System.IO.StreamReader(@"data.txt");
                List<String> Spec= new List<String>();
                while (file.EndOfStream != true)
                {
                    string s = file.ReadLine();
                    if(s.Contains("Spec")) {
                        int a = Convert.ToInt16(s.Length);
                        a = a - 5;
                        string part = s.Substring(5, a);
                        Spec.Add(part);
                    }
                }
