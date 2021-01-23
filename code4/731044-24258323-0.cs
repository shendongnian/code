            foreach (DataGridViewRow row in ItemDg.Rows)
            {
                int qtyEntered = Convert.ToInt16(row.Cells[1].Value);
                if (qtyEntered <= 0)
                {
                    ItemDg[0, count].Style.BackColor = Color.Red;//to color the row
                    ItemDg[1, count].Style.BackColor = Color.Red;
                    ItemDg[0, count].ReadOnly = true;//qty should not be enter for 0 inventory                       
                }
                ItemDg[0, count].Value = "0";//assign a default value to quantity enter
                count++;
            }
        }
