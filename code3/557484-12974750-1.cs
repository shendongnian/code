            int ct1 = 0;
            int i = 0;
            while(i < dt.Rows.Count)
            {
                if ( dt.Rows[i]["Name"].ToString() == "null" + ct1)
                {
                    if ((dt.Rows[i][0] == null || dt.Rows[i][0].ToString() == string.Empty) && (dt.Rows[i][2] == null || dt.Rows[i][2].ToString() == string.Empty))
                    {
                        dt.Rows.RemoveAt(i);
                        i--;
                    }
                    else
                    {
                        dt.Rows[i].SetField<String>(1, "");
                    }
                    ct1++;
                }
                i++;
            }
