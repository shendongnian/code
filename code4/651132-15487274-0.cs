    for (int i = 0; i < cmbTo.Items.Count; i++)
    {
        string st = cmbTo.Items[i].ToString();
        if (st == "" || st.IndexOf("@") == -1)
        {               
            cmbTo.Items.RemoveAt(i);
            i--;
        }
    }
