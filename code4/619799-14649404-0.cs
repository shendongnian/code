            int clickedCount = 0;
    
            private void button1_Click(object sender, EventArgs e)
            {
                clickedCount++;
                if (clickedCount % 2 == 0) { pictureBox1.ImageLocation = @"path"; } else { pictureBox1.ImageLocation = @"path"; }
                
                
            }
