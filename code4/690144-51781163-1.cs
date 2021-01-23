	partial class Program
	{
		static ThreadLocker locker = new ThreadLocker();
		static void Main(string[] args)
		{
			var id = 10;
			lock(locker.GetLocker(id))
			{
			}
		}
    }
