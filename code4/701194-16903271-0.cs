    // constructor called from a static constructor elsewhere
    MyDllLoader(string hardwareFolder) {
        _hardwareFolder = hardwareFolder;
        AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
        SeeIfAlreadyLoaded();
    }
    private void SeeIfAlreadyLoaded() {
        // if the assembly is still in the current app domain then the AssemblyResolve event will
        // never fire.
        // Since we need to know where the assembly is, we have to look for it
        // here.
        Assembly[] assems = AppDomain.CurrentDomain.GetAssemblies();
        foreach (Assembly am in assems)
        {
            // if it matches, just mark the local _loaded as true and get as much
            // other information as you need
        }
    }
    System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args) {
        string name = args.Name;
        if (name.StartsWith("Intermediate.dll,"))
        {
            string candidatePath = Path.Combine(_hardwareFolder, "Intermediate.dll");
            try {
                Assembly assem = Assembly.LoadFrom(candidatePath);
                if (assem != null) {
                    _location = candidateFolder;
                    _fullPath = candidatePath;
                    _loaded = true;
                    return assem;
                }
            }
            catch (Exception err) {
                sb.Append(err.Message);
            }
        }
        return null;
    }
