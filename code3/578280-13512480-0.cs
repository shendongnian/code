    string str = string.Empty;
    foreach (DataRowView drv in listBox1.Items)
    {
           int lvID = int.Parse(drv.Row[listBox1.ValueMember].ToString());
           if (lvID == 5)
           {
                 str = drv.Row[listBox1.DisplayMember].ToString();
                 break;
           }
    }
