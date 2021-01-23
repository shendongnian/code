	public interface IPlate<out T> where T : IWaffle {}
	public interface IWaffle {}
	public class BelgiumWaffle : IWaffle {}
	public class FalafelWaffle : IWaffle {}
	public class HugePlate<T> : IPlate<T> where T : IWaffle {}
	public class SmallPlate<T> : IPlate<T> where T : IWaffle {}
