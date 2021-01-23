    [TestClass]
        public class ZipFileTests
        {
            [ClassInitialize()]
            public static void PreInitialize(TestContext context)
            {
                if (Resources.LocalExtractFolderTruth.Exists)
                    Resources.LocalExtractFolderTruth.Delete(true);
    
                ZipFile.ExtractToDirectory(Resources.WebsiteZip.FullName, Resources.LocalExtractFolderTruth.FullName);
            }
    
            [TestInitialize()]
            public void InitializeTests()
            {
                if (Resources.LocalExtractFolder.Exists)
                    Resources.LocalExtractFolder.Delete(true);
                
            }
    
            [TestMethod]
            public void ExtractTest()
            {
               
                Resources.WebsiteZip.ExtractToDirectory(Resources.LocalExtractFolder);
                
                Assert.IsTrue(Helpers.DirectoryTools.CompareDirectories(
                    Resources.LocalExtractFolderTruth, Resources.LocalExtractFolder));
    
            }
            [TestMethod]
            public async Task ExtractAsyncTest()
            {
         
                await Resources.WebsiteZip.ExtractToDirectoryAsync(Resources.LocalExtractFolder);
                
                Assert.IsTrue(Helpers.DirectoryTools.CompareDirectories(
                   Resources.LocalExtractFolderTruth, Resources.LocalExtractFolder));
            }
            [TestMethod]
            public void ExtractSemaphoreTest()
            {
    
                Resources.WebsiteZip.ExtractToDirectorySemaphore(Resources.LocalExtractFolder);
                Assert.IsTrue(Helpers.DirectoryTools.CompareDirectories(
                   Resources.LocalExtractFolderTruth, Resources.LocalExtractFolder));
            }
            [TestMethod]
            public async Task ExtractSemaphoreAsyncTest()
            {
    
                await Resources.WebsiteZip.ExtractToDirectorySemaphoreAsync(Resources.LocalExtractFolder);
                Assert.IsTrue(Helpers.DirectoryTools.CompareDirectories(
                   Resources.LocalExtractFolderTruth, Resources.LocalExtractFolder));
            }
            
        }
