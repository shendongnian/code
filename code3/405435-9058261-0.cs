FileVersionInfo version = ProcessUtils.GetLoadedModuleVersion("comctl32.dll");
    
if (version != null && version.FileMajorPart >= 6 && version.FileMinorPart >= 1)
{
   // We can use TaskDialog...
}
else
{
   // Use old style MessageBox
}
