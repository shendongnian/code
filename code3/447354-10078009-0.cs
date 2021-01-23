    public enum TestFileType {
        File1,
        File2,
    }
    public class TestFiles
    {
        private static Dictionary<TestFileType, String> filePaths = new Dictionary<TestFileType, String> 
            { 
                { TestFileType.File1, @"TestData\File1.xml" }, 
                { TestFileType.File2, @"TestData\File2.xml" } 
            };
        public static String GetFile(TestFileType fType) {
            return Path.Combine(RootPath() + filePaths[fType]);
        }
    }
    // Use thus: 
    TestFiles.GetFile(TestFileType.File1);
    
