    [System.Runtime.InteropServices.DllImport("user32.dll")]
    extern static bool DestroyIcon(IntPtr handle);
    
    private void buttonConvert2Ico_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog1 = new OpenFileDialog
        openFileDialog1.InitialDirectory = "C:\\Data\\\" ;
        openFileDialog1.Filter = "BitMap(*.bmp)|*.bmp" ;
        openFileDialog1.FilterIndex = 2 ;
        openFileDialog1.RestoreDirectory = true ;
        if(openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            try
            {
                string sFn = openFileDialog1.FileName;
                MessageBox.Show("Filename=" + sFn);
                string destFileName = sFn.Substring(0, sFn.Length -3) +"ico";
                // Create a Bitmap object from an image file.
                Bitmap bmp = new Bitmap(sFn);
                // Get an Hicon for myBitmap. 
                IntPtr Hicon = bmp.GetHicon();
                // Create a new icon from the handle. 
                Icon newIcon = Icon.FromHandle(Hicon);
                //Write Icon to File Stream
                System.IO.FileStream fs = new System.IO.FileStream(destFileName, System.IO.FileMode.OpenOrCreate);
                newIcon.Save(fs);
                fs.Close();
                DestroyIcon(Hicon);
                setStatus("Created icon From=" + sFn + ", into " + destFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read/write file. Original error: " + ex.Message);
            }
        }
    }
