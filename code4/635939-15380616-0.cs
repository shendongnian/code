    const int feedbackinterval = 1000;
    private void btnCopy_Click(object sender, EventArgs e)
    {
        StringBuilder txt2CB = new StringBuilder();
        int[] rows = gridView1.GetSelectedRows();
        if (rows == null) return;
        for (int n = 0; n < rows.Length; n++)
        {
            if ((n % feedbackinterval) == 0) Application.DoEvents();
            if (!gridView1.IsGroupRow(rows[n]))
            {
                var item = gridView1.GetRow(rows[n]) as vWorkOrder;
                txt2CB.AppendLine(String.Format("{0}\t{1}\t{2}",
                item.GroupCode, item.GroupDesc, item.note_no??0));
            }
         }
            Clipboard.SetText(txt2CB.ToString());
    }
