    [TestClass]
    public class SymlinkTest
    {
        [TestInitialize]
        public void SetupFiles()
        {
            if (!File.Exists(@"C:\Temp\SymlinkUnitTest\Original.txt")) throw new Exception("Run Symlinksetup.bat as Admin to create test data.");
        }
        [TestMethod]
        public void OrdinaryFile()
        {
            string file = @"C:\Temp\SymlinkUnitTest\Original.txt";
            string actual = new FileInfo(file).GetSymbolicLinkTarget();
            Assert.IsTrue(actual.EndsWith(@"SymlinkUnitTest\Original.txt"));
        }
        [TestMethod]
        public void FileSymlink()
        {
            string file = @"C:\Temp\SymlinkUnitTest\Symlink.txt";
            string actual = new FileInfo(file).GetSymbolicLinkTarget();
            Assert.IsTrue(actual.EndsWith(@"SymlinkUnitTest\Original.txt"));
        }
        [TestMethod]
        public void OrdinaryDirectory()
        {
            string dir = @"C:\Temp\SymlinkUnitTest";
            string actual = new DirectoryInfo(dir).GetSymbolicLinkTarget();
            Assert.IsTrue(actual.EndsWith(@"SymlinkUnitTest"));
        }
        [TestMethod]
        public void DirectorySymlink()
        {
            string dir = @"C:\Temp\SymlinkUnitTest";
            string actual = new DirectoryInfo(dir).GetSymbolicLinkTarget();
            Assert.IsTrue(actual.EndsWith(@"SymlinkUnitTest"));
        }
    }
