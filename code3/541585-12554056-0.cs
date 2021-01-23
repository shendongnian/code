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
            dialog.ShowDialog(); // check the DialogResult to see if it failed or succeeded.
            var excel = new ExcelQueryFactory();
            excel.FileName = dialog.FileName;
        }
    }
