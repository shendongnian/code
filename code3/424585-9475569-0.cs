    string search = textBox1.Text;
    for (int i = 0; i < staffUsers.Count;)
    {
        if (!(staffUsers[i].staff_name.Contains(search)))
        {
            staffUsers.Remove(staffUsers[i]);
        }
        else
        {
            i++;
        }
    }
