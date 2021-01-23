                Assert.AreEqual(true, target.StartUi());
                XServiceClient client = new XServiceClient();
                Assert.AreEqual(CommunicationState.Created, client.State, "Wrong communication state after UI and client started");
                client.GetSessionID();
                Assert.AreEqual(CommunicationState.Opened, client.State, "Wrong communication state after first call");
