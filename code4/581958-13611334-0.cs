    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextWriter tw = new StreamWriter("NewData.txt");
            for (int i = 0; i < newData.Count; i++) 
            {                   
               tw.Write(newData[i]);
               if(i < newData.Count-1)
               { 
                  tw.Write(",");
               }
            }
            tw.close();
            buttonSave.Enabled = true;
            textBoxLatitude.Enabled = false;
            textBoxLongtitude.Enabled = false;
            textBoxElevation.Enabled = false;
        }
