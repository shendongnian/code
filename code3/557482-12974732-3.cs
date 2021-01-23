    if(resE1.Rows[i].Contains("null") && (resE1.Rows[i]["ID"].ToString() == "") && (resE1.Rows[i]["Comment"].ToString() == ""))
    {
        resE1.Rows[i].Delete();
    }
    bool emptyFlag = false;
    if(resE1.Rows[i].Contains("null"))
    {
        for(int j = 0; j < resE1.Columns.Count; j++)
        {
           if(resE1.Rows[i][j].Equals(""))
            emptyFlag = true;
           else
            emptyFlag = false;
        }
       if(emptyFlag)
        resE1.Rows[i].Delete();
    }
