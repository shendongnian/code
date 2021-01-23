    using Microsoft.VisualBasic.FileIO; 
    private void button1_Click(object sender, EventArgs e)
    {
        TextFieldParser tfp = new TextFieldParser("C:\\Temp\\Test.csv");
        tfp.Delimiters = new string[] { "," };
        tfp.HasFieldsEnclosedInQuotes = true;
        while (!tfp.EndOfData)
        {
            string[] fields = tfp.ReadFields();
            // do whatever you want to do with the fields now...
            // this is to show what we got as the output
            textBox1.AppendText(String.Join("\t", fields) + "\n");
        }
        tfp.Close();
    }
