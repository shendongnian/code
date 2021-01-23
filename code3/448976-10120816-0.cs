        private void btnZoek_Click(object sender, EventArgs e)
        {
            int counter = 0; string line;  
            // Read the file and display it line by line. 
            System.IO.StreamReader file = new System.IO.StreamReader("c:\\log.txt"); 
            while((line = file.ReadLine()) != null)
            {     if ( line.Contains(txtZoek.Text) )     
            {
                txtResult.Text = txtResult.Text + Environment.Newline + line.ToString();                
            }     
            }  
            file.Close(); 
        } 
