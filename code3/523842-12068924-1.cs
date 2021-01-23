    void Main()
        {
            string name = "Organisation";  //Passed in from external source
            var importer = Factory.GetImporter(name);  //returns Importer<Organisation>
            var processor = Factory.GetProcessor(name); //returns OrganisationProcessor
            processor.Process(importer.GetObjects()); //.Process takes List<Organisation>
    		Console.WriteLine (importer.GetObjects().GetType());
        }
    public static class Factory
    {
    	public static Importer GetImporter(string name)
    	{    		
                //add namespace to name here
    		var desiredType = Type.GetType(name);
    		
    		return new Importer(desiredType);
    	}
    	public static Processor GetProcessor(string name)
    	{
                //add namespace to name here
    		var desiredType = Type.GetType(name+"Processor");
    		
    		return (Processor)Activator.CreateInstance(desiredType);
    	}
    }
    
    public class Importer 
    {
    	Type _typeOfEntities;
    	
    	public Importer(Type typeOfEntities)
    	{
    		_typeOfEntities = typeOfEntities;
    	}
        public IList GetObjects()
        {
    		Type generic = typeof(List<>);
    		
    		Type constructed = generic.MakeGenericType(new Type[] {_typeOfEntities});
    		
    		return (IList)Activator.CreateInstance(constructed);
        }
    }
    public interface Processor
    {
    	void Process(IList objects);
    }
    
    public class OrganisationProcessor : Processor
    {
    	public void Process(IList objects)
    	{
                var desiredTypedObject = objects as List<Organisation>;
                if(desiredTypedObject != null)
    		    ProcessImp(desiredTypedObject);
    	}
        private void ProcessImp(List<Organisation> objects)
        {
            Console.WriteLine ("processing Organisation");
        }
    }
    
    public class AddressProcessor
    {
        public void Process(List<Address> objects)
        {
            //Do something by analogy
        }
    }
    
    public class Organisation { }
    
    public class Address { }
