    private void btnZoek_Click(object sender, EventArgs e)
        {
            int counter = 0; string line;  
            // Read the file and display it line by line. 
            System.IO.StreamReader file = new System.IO.StreamReader("c:\\log.txt"); 
            while((line = file.ReadLine()) != null)
            {     if ( line.Contains(txtZoek.Text) )     
            {
                richtextbox1.Text += "\n" + line.ToString();
                txtresult.Text += "\n" + line.ToString();
            }     
            }  
            file.Close(); 
        } 
