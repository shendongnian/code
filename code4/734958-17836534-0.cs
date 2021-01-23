    if (!reader.Read())
            {
                for (int i = 0; i < seriesa.Length; i++)
                {
                    Chart4.Series[seriesa[i]].Points.AddY(0);
                }
            }
            else
            {
                dtSr.Load(reader);
                Chart4.DataSource = dtSr;
                Chart4.Series["s1"].YValueMembers = "KWmittel";
                Chart4.Series["s2"].YValueMembers = "YTD";
                Chart4.Series["s3"].YValueMembers = "soll";
                Chart4.DataBind();
            }
