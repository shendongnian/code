    for (int h = 0; h < Ds.Tables[0].Rows.Count; h++)
    {
        if(Ds.Tables[0].Rows[h].IsNull(0)==true)
        {
            Ds.Tables[0].Rows[h].Delete();
        }
    }
