        private void slider2_Scroll(object sender, EventArgs e)    
        {    
            System.Windows.Forms.TrackBar slider2;    
            slider2 = (System.Windows.Forms.TrackBar)sender;    
            textBox2.Text = "" + slider2.Value.ToString();    
            if (syncOption.Checked == true)    
            {    
                slider1.Value = Convert.ToInt32(slider2.Value);    
                textBox1.Text = slider1.Value.ToString();    
            }    
    
        }
