internal static FileVersionInfo GetLoadedModuleVersion(string name)
{
   Process process = Process.GetCurrentProcess();
   foreach (ProcessModule module in process.Modules)
   {
      if (module.ModuleName.ToLower() == name)
      {
         return module.FileVersionInfo;
      }
      return null;
   }
}
