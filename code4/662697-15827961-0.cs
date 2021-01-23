    var xlData = Excel8OleDbHelper.ImportExcelFile(fileName);
    var viewModel = new MyViewModel(fileName);
    _window = new MyWindow(viewModel);
    _window.ShowDialog();
    
    public class MyViewModel
    {
        public MyViewModel(string filename)
        {
            filename = filename;
        }
    
        private string _filename;
        
        private DataTable _xlData;
        public DataTable XlData
        {
            return _xlData ?? (_xlData = Excel8OleDbHelper.ImportExcelFile(fileName);
        }
    }
