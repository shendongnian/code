    StreamWriter sw = new StreamWriter("test.txt");  // You should include System.IO;
    var textBox = control as TextBox;   
    if (textBox != null)
    {
       if (string.IsNullOrEmpty(textBox.Text))
       {
         textBox.Style["visibility"] = "hidden";
       }
    }
    sw.Write(textBox.Text + ","); 
