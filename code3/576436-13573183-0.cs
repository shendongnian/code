    public class Program
    {
        public static void Main()
        {
        IObservable<long> Sequence1 = Observable.Interval(TimeSpan.FromSeconds(1));
        IObservable<long> Sequence2 = Observable.Interval(TimeSpan.FromSeconds(1));
        //1st subscription
        Sequence1.Timestamp().Buffer(TimeSpan.FromSeconds(5.0)).Subscribe(item1 =>
        Console.WriteLine("Buffer 1: {0} Value: {1}", item1[item1.Count[1].
        Timestamp.ToString("HH:mm:ss"), item1[item1.Count - 1].Value));
        //some delay
        Thread.Sleep(2000);
        //2nd subscription
        Sequence2.Timestamp().Buffer(TimeSpan.FromSeconds(5.0)).Subscribe(item2 =>
        Console.WriteLine("Buffer 2: {0} Value: {1}", item2[item2.Count - 1].
        Timestamp.ToString("HH:mm:ss"), item2[item2.Count - 1].Value));
        Console.ReadLine();
    }
    }
