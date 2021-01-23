    public interface IDocument
    {
        void OpenFile();
        void DoStuff();
        void SaveFile();
    }
    public class Word : IDocument { .... }
    public function RunTheFunctions(IDocument o)
    {
        o.OpenFile();
        o.DoStuff();
        o.SaveFile();
    }
