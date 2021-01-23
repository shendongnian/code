    protected string TextProperty { get; set; }
    
    private void button1_Click(object sender, EventArgs e)
    {
        using (StreamReader reader = new StreamReader(@"C:\Original_Text_File.txt"))
        {
            // read all content file to the string property on your form.
            TextProperty = reader.ReadToEnd();    
        }         
    
    }
    
    private void button2_Click(object sender, EventArgs e)
    {
        using (StreamWriter writer = new StreamWriter(@"C:\Original_Text_File.txt"))
        {
            // write all content of the property to the file.
            writer.Write(TextProperty);    
        }
    }
