    [STAThread]
    public static void Main(string[] args)
    {
        var dialog = new OpenFileDialog
                         {
                             Multiselect = false,
                             Title = "Open Excel Document",
                             Filter = "Excel Document|*.xlsx;*.xls"
                         };
        using (dialog)
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var excel = new ExcelQueryFactory { FileName = dialog.FileName };
                // code executed on opened excel file goes here.
            }
        }
    }
