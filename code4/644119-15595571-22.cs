    using Microsoft.WindowsAPICodePack.Shell;
    using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
    private static string GetFilePropertyItemTypeTextValueFromShellFile(string filePathWithExtension)
    {
       var shellFile = ShellFile.FromFilePath(filePathWithExtension);
       var prop = shellFile.Properties.GetProperty(PItemTypeTextCanonical);
       return prop.FormatForDisplay(PropertyDescriptionFormatOptions.None);
    }
