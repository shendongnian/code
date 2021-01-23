       private void btn_search_search_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("Some file");
            string line = sr.ReadLine();
            string name="";
            string number="";
            while (line != null)
            {
                var m = Regex.Match(line, @"([\w]+):([\d]+)<br>");
                if (m.Success)
                {
                    name = m.Groups[1].Value; 
                    number = m.Groups[2].Value;   // use this name and number variables as per your need
                    line = sr.ReadLine();
                }
                else
                {
                    line = sr.ReadLine();
                }
            }
        }
