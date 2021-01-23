    using EnvDTE80;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;
    public abstract class VsPackage : Package
    {
        ...
        protected DTE2 GetApplication()
        {
            return this.GetService(typeof(SDTE)) as DTE2; 
        }
        ...
    }
