    Type credType = typeof (ClientCredential); //enter here type of your credentials
    PropertyInfo credPropInfo1 = credType.GetTypeInfo().GetDeclaredProperty("ServiceCertificate");
    PropertyInfo credPropInfo2 = credPropInfo1.GetType().GetTypeInfo().GetDeclaredProperty("Authentication");
    PropertyInfo credPropInfo3 = credPropInfo2.GetType().GetTypeInfo().GetDeclaredProperty("CertificateValidationMode");
    credPropInfo3.SetValue(yourObject, 0); // use the int value of the enum, suggested 0 for None
