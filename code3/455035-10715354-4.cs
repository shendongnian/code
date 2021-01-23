    var test6 = client.ClientCredentials.GetType().GetTypeInfo().GetDeclaredProperty("ServiceCertificate").GetValue(client.ClientCredentials);
    var test7 = test6.GetType().GetTypeInfo().GetDeclaredProperty("Authentication").GetValue(test6);
    test7.GetType().GetTypeInfo().GetDeclaredField("certificateValidationMode").SetValue(test7, 0);
    test6.GetType().GetTypeInfo().GetDeclaredField("authentication").SetValue(test6, test7);
    client.ClientCredentials.GetType().GetTypeInfo().GetDeclaredField("serviceCertificate").SetValue(client, test6);
