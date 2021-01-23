    ServicePointManager.Expect100Continue = false;
    var endPointAddress = new EndpointAddress("http://" + cameraAddress + "/onvif/device_service");
    var httpTransportBinding = new HttpTransportBindingElement { AuthenticationScheme = AuthenticationSchemes.Digest };
    var textMessageEncodingBinding = new TextMessageEncodingBindingElement { MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.None) };
    var customBinding = new CustomBinding(textMessageEncodingBinding, httpTransportBinding);
    var passwordDigestBehavior = new PasswordDigestBehavior(adminName, adminPassword);
    var deviceClient = new DeviceClient(customBinding, endPointAddress);
    deviceClient.Endpoint.Behaviors.Add(passwordDigestBehavior);
