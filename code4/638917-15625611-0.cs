    string[] fname = Directory.GetFiles(templatePath); // Gets all the file names from the path assigned to templatePath and assigns it to the string array fname
            // Begin sorting through the file names assigned to the string array fname
            foreach (string file in fname)
            {
                // Remove the extension from the file names and compare the list with the dropdown selected item
                if (System.IO.Path.GetFileNameWithoutExtension(file) != cbTemplates.SelectedItem.ToString())
                {
                    // StreamReader gets the contents from the found file and assigns them to the labels
                    using (var obj = new StreamReader(File.OpenRead(file)))
                    {
                        lbl1.Content = obj.ReadLine();
                        lbl2.Content = obj.ReadLine();
                        lbl3.Content = obj.ReadLine();
                        lbl4.Content = obj.ReadLine();
                        lbl5.Content = obj.ReadLine();
                        lbl6.Content = obj.ReadLine();
                        lbl7.Content = obj.ReadLine();
                        lbl8.Content = obj.ReadLine();
                        lbl9.Content = obj.ReadLine();
                        lbl10.Content = obj.ReadLine();
                        obj.Dispose();
                    }
                }
            }
