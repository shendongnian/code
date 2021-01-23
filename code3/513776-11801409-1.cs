    /// <summary>
    /// Tests for CSPROJ
    /// </summary>
    [TestClass]
    public class TestCSPROJ
    {
        /// <summary>
        /// check if CSPROJ content files exist in disk
        /// </summary>
        [TestMethod]
        public void CsProj_Files_Exist_In_Disk()
        {
            string root = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("\\Solution\\TestResults"))
                + "\\Website\\My.Website\\";
            string websiteProj = root + "My.Website.csproj";
            var list = IOHelper.GetFilesInCSPROJ(websiteProj);
            Assert.IsTrue(list != null, "there are no content files added in Portal6.Website.csproj");
            foreach (var item in list)
            {
                Assert.IsTrue(System.IO.File.Exists(root + item), "FAILED - file not found in disk: " + root + item);
            }
        }
    }
