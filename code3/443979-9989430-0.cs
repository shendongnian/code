    FileInfo registrationsText = new FileInfo(@"name_temp.txt");
                StreamReader registrationsSR = registrationsText.OpenText();
                var registrationsList = registrationListBox.Items.Cast<string>().ToList();
    
                registrationListBox.BeginUpdate();
                registrationListBox.Items.Clear();
    
                if (!string.IsNullOrEmpty(SrchBox.Text))
                {
                    foreach (string str in registrationsList)
                    {
                        if (str.Contains(SrchBox.Text))
                        {
                            registrationListBox.Items.Add(str);
                        }
                    }
                }
                else
                    while (!registrationsSR.EndOfStream)
                    {
                        registrationListBox.Items.Add(registrationsSR.ReadLine());
                    }
                registrationListBox.EndUpdate();
