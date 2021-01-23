    var mock = new Mock<IDeviceAuthorisationRepositioryService>();
    var service = new DeviceAuthorisationService(mock.Object);
    service.UpdateDeviceStatusToActive(....);
    mock.Verify(x => service.UpdatePhoneStatusToActive(), Times.Never());
  
