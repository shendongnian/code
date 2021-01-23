    public enum XmlFile{
        File1,
        File2
    };
    public static class TestFiles{
        const string RelativeDirectory = @"TestData";
        const string XmlExtension = @"xml";
        static string RootPath {
            get
            {
                return Some_DirectoryName_Determined_At_Run_Time_Returned_BySomeOtherModule();
            }
        }
        //overload as necessary for other extensions or pass it as an additional parameter
        public static string GetFullPath(XmlFile file){
            return string.Format(@"{0}{1}\{2}.{3}", RootPath, RelativeDirectory, file, XmlExtension);
        }
    }
