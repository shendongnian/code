        while (row <= dataGridView1.Rows.Count - 1)
        {
          DataGridViewRow gridRow = dataGridView1.Rows[row];
          {
            foreach (DataGridViewCell cell in gridRow.Cells)
            {
              if (cell.Value != null)
              {
                if (cell is DataGridViewTextBoxCell)
                  e.Graphics.DrawString(cell.Value.ToString(),
                      cell.InheritedStyle.Font,
                      new SolidBrush(cell.InheritedStyle.ForeColor),
                      new RectangleF(l, t, w, h),
                      format);
                else if (cell is DataGridViewImageCell)
                  e.Graphics.DrawImage((Image)cell.Value,
                      new RectangleF(l, t, w, h));
              }
            }
          }
          row++;
        }
