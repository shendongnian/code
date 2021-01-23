    public interface IFormatter<in T>
    {
        string Format(T obj);
    }
    public class CItemFormatter : IFormatter<CItem>
    {
        public string Format(CItem item)
        {
            //formatting logic
        }
    }
