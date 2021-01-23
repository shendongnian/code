    public interface IWorkbook
    {
        void Save(...);
    }
    
    class WorkbookWrapper : IWorkbook
    {
        private _workbook;
    
        public WorkbookWrapper(...)
        {
            _workbook = new Workbook(...);
        }
    
        public void Save(...)
        {
            _workbook.Save(...);
        }
    }
