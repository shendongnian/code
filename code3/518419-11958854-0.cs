    void Main(){
	var startTime = DateTime.UtcNow;
	
	//Create an arbitrary number of events.
	var source = Application.DefineEnumerable(() => Enumerable.Range(0, 60).Select(i => PointEvent.CreateInsert(startTime.AddHours(i * 1 ), (double)1)));
	var input = source.ToStreamable(AdvanceTimeSettings.StrictlyIncreasingStartTime);
	//Create a tumbling window that is 10 seconds wide
	var query = from i in input.TumblingWindow(TimeSpan.FromSeconds(10))
		select i.Count();
	query.Dump();
