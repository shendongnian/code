    private void searchButton_Click(object sender, EventArgs e)
    {
        foreach (string fileName in Directory.GetFiles("C:\\ITRS_equipment_log\\", "*.txt"))
        {
            using (StreamReader sw = new StreamReader(fileName))
            {
                string Description = sw.ReadLine();
                bool InStock = sw.ReadLine().Trim() == "1";
                if (Description.Contains(comboBox1.SelectedText))
                {
                    richTextBox1.AppendText("Item '" + Description + "' is " + (InStock ? "in" : "not in") + " stock.\r\n");
                }
            }
        }
    }
