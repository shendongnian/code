                string txt = "";
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < t.Rows.Count; i++)
                {
                    sb.Append(t.Rows[i][0]); 
                    sb.Append("\t");
                    sb.Append(t.Rows[i][1]);
                    //and so on...
               }
               string txt = sb.ToString();
