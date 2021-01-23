    string bindingType = "BasicHttpBinding";
    System.ServiceModel.Channels.Binding myBinding;
    if (bindingType == "BasicHttpBinding") { myBinding = new BasicHttpBinding(); }
    if (bindingType == "NetTcpBinding") { myBinding = new NetTcpBinding(); }
    if (bindingType == "WSHttpBinding") { myBinding = new WSHttpBinding(); }
