    public class ThreadSafeSample
    {
    private decimal sum = 0;
    private uint count = 0;
    private static object locker = new object();
    public void Add(decimal value)
    {
        lock (locker)
        {
            sum += value;
            count++;
        }
    }
    public decimal AverageMove => count > 0 ? sum / count : 0;
}
