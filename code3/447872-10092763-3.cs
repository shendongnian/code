    public interface IVideoConverter
    {
         IInputReader  Reader {get;set;}
         IOutputWriter Writer {get;set;}
         void Convert();
    }
