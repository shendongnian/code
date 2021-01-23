                private static bool AuthenticateUserOnRemote(string server, string userName, string password)
                {
                    var connected = PinvokeWindowsNetworking.connectToRemote(server, userName, password);
                    var disconnected = PinvokeWindowsNetworking.disconnectRemote(server);
                    return connected == null;
                }
