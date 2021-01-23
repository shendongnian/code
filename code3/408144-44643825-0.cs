    public V[] getV(DataTable dtCloned)
    {
 
        V[] objV = new V[dtCloned.Rows.Count];
        MyClasses mc = new MyClasses();
        int i = 0;
        int intError = 0;
        foreach (DataRow dr in dtCloned.Rows)
        {
            try
            {
                V vs = new V();
                vs.R = int.Parse(mc.ReplaceChar(dr["r"].ToString()).Trim());
                vs.S = Int64.Parse(mc.ReplaceChar(dr["s"].ToString()).Trim());
                objV[i] = vs;
                i++;
            }
            catch (Exception ex)
            {
                //
                DataRow row = dtError.NewRow();
                row["r"] = dr["r"].ToString();
                row["s"] = dr["s"].ToString();
                dtError.Rows.Add(row);
                intError++;
            }
        }
        return vs;
    }
