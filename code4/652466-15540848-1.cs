    enter code here
 
     private void InsertNewRow(string id, string text, int type)
        {
            EditorRow row = new EditorRow(id);
            row.Name = "row" + id;
            row.Properties.ImageIndex = type;
            //vGridControl1.Appearance.ReadOnlyRecordValue.ForeColor = ColorText;
            M_Objects myColorObject = new M_Objects();
            if (GetObjectById(id, ref myColorObject) >= 0)
            {
                m_Color = myColorObject.Color;
            }
            System.Drawing.Color ColorText = Color.FromArgb(m_Color.r, m_Color.g, m_Color.b);
            row.Appearance.ForeColor = ColorText;//here I try to change color
            row.Appearance.Options.UseForeColor = true;//It does not work
            if (vGridControl1.RepositoryItems.Count == 0)
                vGridControl1.RepositoryItems.Add("TextEdit");
            row.Properties.RowEdit = vGridControl1.RepositoryItems[0];
            row.Properties.Value = text;
            row.Height = 28;
            row.Properties.ReadOnly = true;
            vGridControl1.Rows["MainRow"].ChildRows.Add(row);//I don't write this code. Is it right?
        }
