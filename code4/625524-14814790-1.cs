            if (atrOk == true)
            {
                DataGridViewImageCell cellAtr = row.Cells[8] as DataGridViewImageCell;
                cellAtr.Value = (System.Drawing.Image)Properties.Resources.Bullet_Green;
            }
            else
            {
                DataGridViewImageCell cellAtr = row.Cells[8] as DataGridViewImageCell;
                cellAtr.Value = (System.Drawing.Image)Properties.Resources.Bullet_Red;
            }
            if (prOk == true)
            {
                DataGridViewImageCell cellPr = row.Cells[9] as DataGridViewImageCell;
                cellPr.Value = (System.Drawing.Image)Properties.Resources.Bullet_Green;
            }
            else
            {
                DataGridViewImageCell cellAtr = row.Cells[8] as DataGridViewImageCell;
                cellAtr.Value = (System.Drawing.Image)Properties.Resources.Bullet_Red;
            }
            if (poOk == true)
            {
                DataGridViewImageCell cellPo = row.Cells[10] as DataGridViewImageCell;
                cellPo.Value = (System.Drawing.Image)Properties.Resources.Bullet_Green;
            }
            else
            {
                DataGridViewImageCell cellAtr = row.Cells[8] as DataGridViewImageCell;
                cellAtr.Value = (System.Drawing.Image)Properties.Resources.Bullet_Red; 
            }
