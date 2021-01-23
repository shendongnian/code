     Document = new XmlDocument();
            try
            {
                openFileDialog1.ShowDialog();
                Document.Load(openFileDialog1.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            ListOfNodes = Document.SelectNodes("ReceiveAccountSettings");
