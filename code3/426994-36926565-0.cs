    public static bool ValidateZipFile(string fileToTest)
    {
        bool result;
        //Added using statement to fix IOAccess Blocking
        using (ICSharpCode.SharpZipLib.Zip.ZipFile zip = new ICSharpCode.SharpZipLib.Zip.ZipFile(fileToTest))
        {
            result = zip.TestArchive(true, TestStrategy.FindFirstError, null);
        }
        return result;
    }
