      [TestMethod]
            public void AuthoriseDeviceProfileTest()
            {
                long paramUserID=1, string paramClientMakeModel=test";
                IDeviceAuthorisationService DeviceAuthorisationService= new DeviceAuthorisationService();
    
                try
                {
    
                    DeviceAuthorisationService.AuthoriseDeviceProfile(paramUserID, paramClientMakeModel);
                    Assert.IsNull(paramUserID);
    
                }
                catch (Exception e)
                {
                    Assert.AreNotEqual("Exception of type was thrown", e.Message);
                }
            }
        }
