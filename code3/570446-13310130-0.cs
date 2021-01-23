      bool alreadycopying = false;
        private void listView1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.LeftButton == MouseButtonState.Pressed && alreadycopying == false)
                {
                    alreadycopying = true;
                    System.IO.StreamWriter test = new System.IO.StreamWriter(@"C:\SuperSecretTestFile.txt");
                    test.WriteLine("Test");
                    test.Close();
                    List<String> testlist = new List<string>();
                    testlist.Add(@"C:\SuperSecretTestFile.txt");
                    DataObject d = new DataObject();
                    d.SetData(DataFormats.FileDrop, testlist.ToArray<string>());
                    DragDrop.DoDragDrop(listView1, d, DragDropEffects.All);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
