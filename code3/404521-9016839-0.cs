    private Assembly AppDomain_AssemblyResolve(object sender, ResolveEventArgs e)
        {
            try
            {
                string strTempAssmbPath = ExtensionsFolder + e.Name.Substring(0, e.Name.IndexOf(",")) + ".dll";
                return Assembly.LoadFile(strTempAssmbPath);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return null;
        }
