    DateTime start = DateTime.Now;
	Thread.Sleep(1234);
	DateTime end = DateTime.Now;
	TimeSpan diff = (end  - start);
	Console.WriteLine("Total processing time... {0:00}:{1:00}:{2:00}.{3}", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
	// OUTPUT   Total processing time... 00:00:01.234
