    pwStartTime = lender.ApplicationWindows.FirstOrDefaultDateTime(pwPeriod, dateToCheck);
    pwStartTime = lender.TransferWindows.FirstOrDefaultDateTime(pwPeriod, dateToCheck);
    
    public interface IWindow
    {
    	string Name { get; }
    	public DateTime StartTime { get; }
    	public DateTime EndTime { get; }
    }
    
    public class ApplicationWindow : IWindow
    {
    	public string Name { get; set; }
    	public DateTime StartTime { get; set; }
    	public DateTime EndTime { get; set; }
    }
    
    public class TransferWindow : IWindow
    {
    	public string Name { get; set; }
    	public DateTime StartTime { get; set; }
    	public DateTime EndTime { get; set; }
    }
    
    public static class IWindowExt
    {
        public static DateTime FirstOrDefaultDateTime(this IEnumerable<IWindow> windows, string pwPeriod, DateTime dateToCheck)
        {
            return windows
                    .Where(w => w.Name == pwPeriod && w.EndTime.TimeOfDay > dateToCheck.TimeOfDay)
                    .Select(w => w.StartTime)
                    .FirstOrDefault();
        }
    }
