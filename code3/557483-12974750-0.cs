            int ct1 = 0;
            int i = 0;
            while(i < dt.Rows.Count)
            {
                if ( dt.Rows[i]["Name"].ToString() == "null" + ct1)
                {
                    if (ct1 == 0)
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
