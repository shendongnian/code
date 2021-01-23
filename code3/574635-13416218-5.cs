     private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(myMethod("Adam", "The Title"));
        }
        string myMethod(string name, string title)
        {
            return name + " " + title;             
        }
