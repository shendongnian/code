            private void button2_Click(object sender, EventArgs e)
            {                
               if (!IsFileLocked(imageFileinfo))
                {                 
                    imageFileinfo.Delete();
                }
            }
     
