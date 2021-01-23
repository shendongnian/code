    DialogResult result = openFileDialog.ShowDialog();
                
                Collection<Info> _infoCollection = new Collection<Info>();
                Collection<string> listOfSubDomains = new Collection<string>();
                
                string[] row;
                string line;
    
                // READ THE FILE AND STORE IT IN INFO OBJECT AND STORE TAHT INFO OBJECT IN COLLECTION
                try
                {
                    using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                    {
                        while((line = reader.ReadLine()) != null)
                        {
                            Info _info = new Info();
                            row = line.Split(' ');
    
                            _info.FirstName = row[0];
                            _info.LastName = row[1];
                            _info.Email = row[2];
                            _info.Id = Convert.ToInt32(row[3]);
    
                            _infoCollection.Add(_info);
                            
                        }
                    }
    
    catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
