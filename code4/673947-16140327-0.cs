    private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (String.IsNullOrEmpty(directory))
        {
            e.Cancel = false;
        }
        else
        {
            string time = DateTime.Now.ToString("hh:mm");
            using(TextWriter msg = new StreamWriter(directory, true))
            { 
                msg.WriteLine(" (" + time + ") == " + uName + " Has Left The Chat == ");
                msg.Close();
            }
            e.Cancel = false;
        }
    }
