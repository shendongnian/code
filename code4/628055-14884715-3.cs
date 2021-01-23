    var sut = new MyInstallerClass();
    int oldCount = sut.ApplicationShouldBeInstalled_Count;
    sut.InstallApplications();
    int newCount = sut.ApplicationShouldBeInstalled_Count;
    Assert.AreEqual(oldCount + sut.Apps.Count, newCount);
