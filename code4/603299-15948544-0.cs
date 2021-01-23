    System.IO.FileNotFoundException : Could not load file or assembly 'Old.Interfaces, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null' or one of its dependencies. The system cannot find the file specified.
       at System.Reflection.RuntimeAssembly._nLoad(AssemblyName fileName, String codeBase, Evidence assemblySecurity, RuntimeAssembly locationHint, ref StackCrawlMark stackMark, IntPtr pPrivHostBinder, Boolean throwOnFileNotFound, Boolean forIntrospection, Boolean suppressSecurityChecks)
       at System.Reflection.RuntimeAssembly.InternalLoadAssemblyName(AssemblyName assemblyRef, Evidence assemblySecurity, RuntimeAssembly reqAssembly, ref StackCrawlMark stackMark, IntPtr pPrivHostBinder, Boolean throwOnFileNotFound, Boolean forIntrospection, Boolean suppressSecurityChecks)
       at System.Reflection.RuntimeAssembly.InternalLoad(String assemblyString, Evidence assemblySecurity, ref StackCrawlMark stackMark, IntPtr pPrivHostBinder, Boolean forIntrospection)
       at System.Reflection.RuntimeAssembly.InternalLoad(String assemblyString, Evidence assemblySecurity, ref StackCrawlMark stackMark, Boolean forIntrospection)
       at System.Reflection.Assembly.Load(String assemblyString)
       at System.UnitySerializationHolder.GetRealObject(StreamingContext context)
       at System.Runtime.Serialization.ObjectManager.ResolveObjectReference(ObjectHolder holder)
       at System.Runtime.Serialization.ObjectManager.DoFixups()
       at System.Runtime.Serialization.Formatters.Binary.ObjectReader.Deserialize(HeaderHandler handler, __BinaryParser serParser, Boolean fCheck, Boolean isCrossAppDomain, IMethodCallMessage methodCallMessage)
       at System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize(Stream serializationStream, HeaderHandler handler, Boolean fCheck, Boolean isCrossAppDomain, IMethodCallMessage methodCallMessage)
       at System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize(Stream serializationStream)
       [...]
