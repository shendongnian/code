         public void RequestLocationTest()
                {
                    var target = new TestService.BingEngineClient();
                    var address = string.Format("3700 Kingwood Drive, {0}, {1}","Kingwood", "TX");
                    var actual = target.RequestLocation(address);
                    Assert.IsNotNull(actual);
                }
