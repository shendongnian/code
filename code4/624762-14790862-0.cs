    //Interface with a Type parameter to specify the return type of the method
    public interface IChart<T>
    {
    	IEnumerable<T> HourlyChart();
    }
    
    //How to implement the interface
    public class HourlyDeviceChart : IChart<HourlyDeviceChart>
    {
    	public IEnumerable<HourlyDeviceChart> HourlyChart()
    	{
    		//Do work
    	}
    }
        
    //Your new method with a constraint applied
    IEnumerable<T> GetChart<T>(string chartType) where T : IChart<T>
    {
    	return T.HourlyChart();
    }
