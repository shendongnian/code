    class Excelprocessor: FileProcessor 
    {
        public override void Process(string path)
        {
        }
        public override bool CanHandle(string path)
        {
            return path.EndsWith(".xlsx");
        }
    }
