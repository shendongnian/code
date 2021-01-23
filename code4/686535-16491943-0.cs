    public abstract class DayInfoA<T>
    {
        public virtual T GetInfo()
        {
            .......
        }
    }
    public class DayInfoB<T> : DayInfoA<T>
    {
        private T info;
        public DayInfoB(T data)
        {
            info = data;
        }
        public override T GetInfo() // << This
        {
          .........
        }
    }
