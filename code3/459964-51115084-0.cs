    public class StopwatchPlus : Stopwatch
    {
    	private TimeSpan AddedTime { get; set; }
    	public StopwatchPlus() { AddedTime = new TimeSpan(0); }
    	public TimeSpan Elapsed { get { return base.Elapsed.Add(AddedTime); } }
    	public void Add(TimeSpan time) { AddedTime = AddedTime.Add(time); }
    }
