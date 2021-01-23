        string stu_name_1 = listBox4.SelectedItem.ToString();
        string stu_name_2 = listBox6.SelectedItem.ToString();
        string add = stu_name_1 +"/"+ stu_name_2;
        Directory.CreateDirectory(add);
        OpenFileDialog sf = new OpenFileDialog();
        Dictionary<string, string> imageDictionary = new Dictionary<string, string>();
        sf.Multiselect = true;
        if (sf.ShowDialog() == DialogResult.OK)
        {
            listView1.Items.Clear();//Clear first
            string[] files = sf.FileNames;            
            foreach (string file in files)
            {
                // Use static Path methods to extract only the file name from the path.
                string fileName = System.IO.Path.GetFileName(file);
                string destFile = System.IO.Path.Combine(add, fileName);
                Image imgToAdd = Image.FromFile(file);
                imgToAdd.Tag = file;
                System.IO.File.Copy(file, destFile, true);
                imageList1.Images.Add(imgToAdd);//Suppose the imageList1 is dedicated to your listView1 only.
                listView1.Items.Add(fileName, imageList1.Images.Count-1);
                //imageDictionary.Add(Path.GetFileName(file), file);
            }
        }
