       void radGridView1_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "Val")
            {
                e.Row.Cells["Colname"].Value = (int)e.Value + 'someting';
            }
        }
