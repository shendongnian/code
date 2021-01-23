     protected void btnShow_Click(object sender, EventArgs e)
    {
            System.IO.StreamWriter stringWriter= new System.IO.StreamWriter("c:\\test.txt");
            foreach (Control control in Panel1.Controls)
            {
                  var textBox = control as TextBox;   
                  if (textBox != null)
                 {
                                 if (string.IsNullOrEmpty(textBox.Text))
                                 {
                                 textBox.Style["visibility"] = "hidden";
                                 }
                stringWriter.Write( textBox.Text+","); // Write text to textfile. 
            }  // end of if loop              
        }
