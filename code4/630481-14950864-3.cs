    public class CsvDataMigrationController
    {
        private string targetTypeName = ...;
        public void ProcessFile(string path)
        {
            var recordType = Type.GetType(this.targetTypeName);
            var records = _provider.GetData(path, recordType);
            _migration.Migrate(records);
        }
    }
