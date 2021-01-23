    using Microsoft.WindowsAPICodePack.Shell;
    using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
    private static string GetFilePropertyItemTypeTextValueFromShellFile(string filepath)
    {
       var shellFile = ShellFile.FromFilePath(filepath);
       var prop = shellFile.Properties.GetProperty(PItemTypeTextCanonical);
       return prop.FormatForDisplay(PropertyDescriptionFormatOptions.None);
    }
