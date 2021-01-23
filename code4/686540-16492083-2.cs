    void Main()
    {
        IDayInfo dayInfo = new DayInfo<string>("hi!");
        object info = dayInfo.GetInfo(); //info == "hi!"
    }
    public interface IDayInfo
    {
        object GetInfo();
    }
    public interface IDayInfo<out T> : IDayInfo
    {
        new T GetInfo();
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
    	object IDayInfo.GetInfo()
    	{
    		return this.GetInfo();
    	}
    }
