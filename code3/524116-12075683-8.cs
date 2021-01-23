    public class MyClassFactory
    {
    	public MyClass<T> MakeMyClassFor<T>(IRecordedItemsProcessor<T> processor)
    	{
    	    var processorGenericType = processor.GetType()
    											.GetInterfaces()
    											.Single(intr=>intr.Name == "IRecordedItemsProcessor`1")
    											.GetGenericArguments()[0];
    		var myClassType = typeof(MyClass<>).MakeGenericType(processorGenericType);
    		return Activator.CreateInstance(myClassType, processor) as MyClass<T>;
    	}
    }
