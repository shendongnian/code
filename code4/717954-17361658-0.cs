    for (int a = 0; a < chkProvision.Items.Count; a++)
    {
        if (chkProvision.GetItemChecked(a))
            comm.Parameters.AddWithValue("@Provision", SqlDbType.Char).Value = chkProvision.Items[a].ToString();
        else
            comm.Parameters.AddWithValue("@Provision", "");
    }     
