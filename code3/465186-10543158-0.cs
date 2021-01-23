    if (dialogResult == DialogResult.Yes)
    {
        FileStream file = new FileStream("test.txt", FileMode.OpenOrCreate, FileAccess.Write);
        StreamReader sr = new StreamReader(file);
        task1_name.Text = sr.ReadLine();
        task1_desc.Text = sr.ReadLine();
        task1_date.Value = DateTime.Parse(sr.ReadLine());
        task1_checked.Checked = bool.Parse(sr.ReadLine());
        sr.Close();
    }
