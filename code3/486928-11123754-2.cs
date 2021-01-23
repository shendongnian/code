    //WARNING: all code typed in SO window
    public class DeleteMapsCommand : ICommand
    {
        private Database _db;
        public DeleteMapsCommand(Database db)
        {
            _db = db;
        }
        public void CanExecute(object parameter)
        {
            //only allow delete if the parameter passed in is a valid Map
            return (parameter is Map);
        }
        public void Execute(object parameter)
        {
            var map = parameter as Map;
            if (map == null) return;
            _db.Delete(map);
            _db.Commit();
        }
        public event EventHandler CanExecuteChanged; //ignore this for now
    }
