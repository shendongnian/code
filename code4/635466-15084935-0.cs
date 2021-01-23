            foreach (GridViewRow r in GridView1.Rows)
            {
                int val1 = 0;
                int val2 = 0;
                int val3 = 0;
                int val4 = 0;
                int val5 = 0;
                int.TryParse(r.Cells[5].Text, out val1);
                int.TryParse(r.Cells[6].Text, out val1);
                int.TryParse(r.Cells[7].Text, out val1);
                int.TryParse(r.Cells[8].Text, out val1);
                int.TryParse(r.Cells[9].Text, out val1);
                int I = (val1 + val2 + val3 + val4 + val5);
                r.Cells[10].Text = I.ToString();
            }
