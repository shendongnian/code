    [TestClass]
    public class UnitTest8
    {
        [TestMethod]
        public void TestJasonFileFolder()
        {
            var folder = new FileFolder();
            folder.Folder = new FileFolder { Name = "Parent" };
            folder.Name = "Something";
            var document = new Document { Folder = folder, Id = 1 };
            var test = JsonConvert.SerializeObject(document);
            Assert.IsNotNull(test);
        }
    }
    public class Document
    {
        public int Id { get; set; }
        public FileFolder Folder { get; set; }
        public FileFolder FolderParent
        {
            get
            {
                return this.Folder.Folder;
            }
        }
    }
    public class FileFolder
    {
        public string Name { get; set; }
        public FileFolder Folder { get; set; }
    }
