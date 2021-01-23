            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                priority = row.Cells[3].EditedFormattedValue.ToString();
                switch (priority)
                {
                    //Change font 
                    case "Urgent":
                        row.Cells[3].Style = BoldRed;
                        break;
                    case "Haute":
                        row.Cells[3].Style = Red;
                        break;
                    case "Normale":
                        row.Cells[3].Style = Black;
                        break;
                    default:
                        row.Cells[3].Style = Black;
                        break;
                }
            }
