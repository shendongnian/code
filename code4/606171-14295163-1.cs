     // note the signature change here (async + Task)
     [TestMethod]
        async public Task _LocalFolder_Test()
        {
        	Class1 ke = new Class1();
            // synchronous call to SetupStorageFolders - note the await
            await ke.SetUpStorageFolders();
            
        	StorageFolder folder = ke._LocalFolder;
         
        	string folderName = folder.Name;
          
        	Assert.IsTrue(folderName == "TestFolder");
        }
