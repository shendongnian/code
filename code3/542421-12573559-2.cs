        private void slider1_Scroll(object sender, EventArgs e) 
        { 
            System.Windows.Forms.TrackBar slider1; 
            slider1 = (System.Windows.Forms.TrackBar)sender; 
            textBox1.Text = "" + slider1.Value.ToString(); 
            if (syncOption.Checked == true) 
            { 
                slider2.Value = Convert.ToInt32(slider2.Value); 
                textBox2.Text = slider2.Value.ToString(); 
            } 
 
        }//
