	partial class Program
	{
		static ThreadLockerByID<int> locker = new ThreadLockerByID<int>();
		static void Main(string[] args)
		{
			var id = 10;
			using(locker.AcquireLock(id))
			{
			}
		}
    }
