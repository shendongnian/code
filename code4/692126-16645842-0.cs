      public string [] RowText
        {
            get
            {
                List<string> text = new List<string>();
                foreach (DataGridViewRow row in datagridview1.Rows)
                {
                    text.Add(row.Cells[i].Value.ToString());
                }
                return text.ToArray();
            }
        }
