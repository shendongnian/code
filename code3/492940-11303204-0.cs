          foreach (DataGridViewColumn col in dataGridView1.Columns)
          {
            e.Graphics.DrawString(col.HeaderText,
                col.InheritedStyle.Font,
                new SolidBrush(col.InheritedStyle.ForeColor),
                new RectangleF(l, t, w, h),
                format);
          }
