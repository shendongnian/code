    ref class Container {
    public:
        static ConcurrentDictionary<String^, Assembly^>^ LoadedAssemblies = gcnew ConcurrentDictionary<String^, Assembly^>();
    };    
    
    static Assembly^ MyResolveEventHandler(Object^ sender, ResolveEventArgs^ args)
    {
    	AssemblyName^ assemblyName = gcnew AssemblyName(args->Name);
    	String^ assemblyFileName = ".\\" + assemblyName->Name + ".dll";
    
    	if (!Container::LoadedAssemblies->ContainsKey(assemblyFileName))
    	{
    		Assembly^ loadedAssembly = LoadAssembly(assemblyFileName);
    		return Container::LoadedAssemblies->GetOrAdd(assemblyFileName, loadedAssembly);
    	}
    
    	return nullptr;
    }
