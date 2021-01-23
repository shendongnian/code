     UserMetaData parameter = null;
     var storageManager = new Mock<IStorageManager>(); 
     storageManager
        .Setup(e => e.Add(It.IsAny<UserMetaData>()))
        .Callback((UserMetaData metaData) => parameter = metaData);
    
     Assert.That(parameter.FirstName, Is.EqualTo("FirstName1")); //If using fluent NUnit
