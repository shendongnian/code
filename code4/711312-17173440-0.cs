    class Program
    {
        public string PathForSavingFiles { get; set; }
    }
    
    abstract class FileBase
    {
        private readonly Program program;
    
        protected FileBase(Program program)
        {
            this.program = program;   
        }
    
        public void Save()
        {
            Save(program.PathForSavingFiles);
        }
    
        protected abstract void Save(string path);
    }
    
    class TxtFile : FileBase { ... }
    class XlsxFile : FileBase { ... }
    // etc
