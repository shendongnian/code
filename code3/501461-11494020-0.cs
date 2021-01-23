    void radioButtons_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton rb = sender as RadioButton;
        if (rb != null)
        {
            if (rb.Checked)
            {
                // Only one radio button will be checked
                Console.WriteLine("Changed: " + rb.Name);
            }
        }
    }
