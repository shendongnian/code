    public interface IVideoConverter
    {
       bool IsSUpported(string inputId, string outputID);
       void Convert();
    }
