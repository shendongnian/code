    public void LoadLang(string filename) {
       Assembly langpackAssembly;
       ILangPackDescriptor descriptor;
       ILangPackInit initializer;
      
       langpackAssembly = Assembly.LoadFrom(filename);
       Type[] langpackTypes = langpackAssembly.GetExportedTypes();
       
       foreach( Type foundType in langpackTypes ) {
            if ( foundType.GetInterfaces().Contains<Type>( typeof(ILangPackDescriptor) ) ) {
                descriptor = Activator.CreateInstance(foundType);
            }
            if ( foundType.GetInterfaces().Contains<Type>( typeof(ILangPackInit) ) ) {
                initializer = Activator.CreateInstance(foundType);
            }
       }
       // If the passed-in file was the langpack.en-US.dll file, then this 
       // calls langpack.en-US.dll's EnUsLangPackInit.Init() method.
       initializer.Init();
    }  
