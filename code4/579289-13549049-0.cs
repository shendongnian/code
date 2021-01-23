         private void radGridView1_CellValidating(object sender, CellValidatingEventArgs e)
         {
            String[] Acceptable = new string[] {"c", "d"};
            if (e.Value != null && e.ColumnIndex == 4)
            {
                if(e.Value != e.OldValue)
                {
                    if (!Acceptable.Contains(e.Value))
                    {
                        e.Cancel = true;
                    }
                }
            }
        }
