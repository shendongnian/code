    public partial class ImportView<T> : Form
    {
        private IParser<T> parser;
        private IInsertOrUpdateList<T> repository;
        private DataTable dataToParse;
    
        public ImportView(DataTable dataToParse)
        {
            this.parser = new Parser<T>();
            this.repository = new Repo<T>();
            this.dataToParse = dataToParse;
        }
    
        public void ParseAndInsertIntoDB()
        {
            repository.InsertOrUpdate(parser.ParseDataTableToList(dataToParse, null));
        }
    }
      
  
