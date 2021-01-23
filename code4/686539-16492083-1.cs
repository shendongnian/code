    void Main()
    {
    	IDayInfo<object> dayInfo = new DayInfo<string>("hi!");
    	object info = dayInfo.GetInfo(); //info == "hi!"
    }
    public interface IDayInfo<out T>
    {
        T GetInfo();
    }
    
    public class DayInfo<T> : IDayInfo<T>
    {
        private T info;
        public DayInfo(T data)
        {
            info = data;
        }
    
        public T GetInfo()
        {
            return info;
        }
    }
