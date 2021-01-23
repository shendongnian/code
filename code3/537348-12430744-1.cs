    private void button1_Click(object sender, EventArgs e) 
    { 
        DialogResult result = this.openFileDialog1.ShowDialog(); 
        if (result == DialogResult.OK) 
        { 
            string[] Nomarchivo = this.openFileDialog1.FileNames; 
            string NomDirec = Path.GetDirectoryName(Nomarchivo[0]); 
            for (int a = 0; a <= Nomarchivo.Length - 1; a++) 
            { 
                //the name we are looking for.
                List<string> namesWeAreLookingFor = new List<string>();
                string NomDirGral = Nomarchivo[a].Remove(Nomarchivo[a].Length - 7, 7); 
                string NomGral = NomDirGral.Replace(NomDirec, " "); 
                NomGral = NomGral.Remove(0, 2); 
                foreach (string f in Directory.GetFiles(NomDirec, NomGral + "*")) 
                    this.listBox1.Items.Add(f); 
                foreach (string h in Directory.GetFiles(NomDirec, "resume*")) 
                {
                    this.listBox1.Items.Add(h); 
                    var nameLines = File.ReadLines(NomDirec + @"\" + h);
                    foreach (var item in nameLines)
                    {
                        //do whatever you need to get a name in this file here
                        //...
                                    
                        //Assuming there is one name per line, add the name to the list
                        namesWeAreLookingFor.Add(item);
                    }
                }
                foreach (string t in Directory.GetFiles(NomDirec, "ESSD1*")) 
                {
                    this.listBox1.Items.Add(t); 
                    //try to access the file so we can read line 6 using new .NET 4 method 
                    var lines = File.ReadLines(NomDirec + @"\" + t);
                    //see if we even have 6 lines
                    if (lines.Count() < 6)
                        continue;
                    String line6 = lines.ElementAt(5);
                    //loop through the names we pulled
                    foreach (var item in namesWeAreLookingFor)
                    {
                        //see if line 6  containes that name.
                        if (line6.Contains(item))
                        {
                            //if it exists, then add it to the list and exit the loop.
                            this.listBox1.Items.Add(t);
                            break;
                        }
                    }
                }
            } 
            string[] list1 = new string[listBox1.Items.Count]; 
            for (int b = 0; b <= listBox1.Items.Count - 1; b++) 
            { 
                list1[b] = listBox1.Items[b].ToString(); 
            } 
            string[] list2 = list1.Distinct().ToArray(); 
            foreach (string g in list2) 
                this.listBox2.Items.Add(g); 
 
            Class1 arr1 = new Class1(); 
            arr1.array(listBox2); 
        } 
        else { Close(); } 
