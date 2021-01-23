        for (int i = 0; i < linesGrid.Items.Count - 1; i++)
        {
            System.Data.DataRowView item = (System.Data.DataRowView)linesGrid.Items[3];
            //fetch columns
            LineID = item.Row[0].ToString();
            MessageBox.Show(LineID);
            Connection_Type = item.Row[1].ToString();
            MessageBox.Show(Connection_Type);
        }
