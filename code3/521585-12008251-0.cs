    private static void Highlight(object sender, EventArgs e)
    {
        currentRow.DefaultCellStyle.BackColor = Color.Brown;
        System.Threading.Thread.Sleep(2000);
        currentRow.DefaultCellStyle.BackColor = Color.White;
    }
