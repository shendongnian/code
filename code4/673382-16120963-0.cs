    // interface for your document classes
    interface IDocument
    {
        void OpenFile();
        void DoStuff();
        void SaveFile();
    }
    // Word implements IDocument
    class Word : IDocument
    {
        public void OpenFile() { /* ... */ }
        public void DoStuff() { /* ... */ }
        public void SaveFile() { /* ... */ }
    }
    
    // later
    public function RunTheFunctions(IDocument o)
    {
        o.OpenFile();
        o.DoStuff();
        o.SaveFile();
    }
    // usage
    IDocument doc = new Word();
    RunTheFunctions(doc);
