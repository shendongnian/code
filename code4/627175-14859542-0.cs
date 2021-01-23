    private void Form1_Load(object sender, EventArgs e)
            {
    
                const string f = "list.txt";
    
                List<string> myList = new List<string>();
    
                using (StreamReader r = new StreamReader(f))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        myList.Add(line);
                    }
                }
    
                var listString = new StringBuilder()
                foreach (string s in myList)
                {
                    listString.Append(Environment.Newline)
                    listString.Append(s);              
    
                }
                 textBox1.Text = listString.ToString();
    
            }
