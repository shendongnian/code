    private void btn_Convert(object sender, EventArgs e)
        {
            string newName = System.IO.Path.GetFileNameWithoutExtension(CurrentFile);
            newName = newName + ".tif";
            try
            {
                img.Save(newName, ImageFormat.Tiff);
            }
            catch (Exception ex)
            {
                string error = ee.Message.ToString();
                MessageBox.Show(MessageBoxIcon.Error);
                
            }
            textBox2.Text = System.IO.Path.GetFullPath(newName.ToString());
        }
