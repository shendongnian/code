    [TestClass]
    public class AssemblyInitialize
    {
    	/// <summary>
    	/// Method which gets executed once per unit test session. The purpose of this method is to reference any loosely coupled
    	/// assemblies so that they get included in the unit test session. If no code actually references a given assembly, even if its
    	/// technically a project reference, it will not be copied to the test output folder.
    	/// </summary>
    	[AssemblyInitialize]
    	public static void InitializeReferencedAssemblies(TestContext context)
    	{
    		List<Type> looselyCoupledTypes = new List<Type>
    										 {
    											 typeof(AlertManagement),
    											 typeof(Naming),
    										 };
    
    		looselyCoupledTypes.ForEach(x => Console.WriteLine("Including loosely coupled assembly: {0}",
    														   x.Assembly.FullName));
    	}
    }
