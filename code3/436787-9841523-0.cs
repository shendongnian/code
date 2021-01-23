    X509Certificate2 endCert = new X509Certificate2(
            Convert.FromBase64String(
                "MIIE8zCCA9ugAwIBAgIQSBDq+mlsLsCZqWMIWj/YADANBgkqhkiG9w0BAQUFADA8MQswCQYDVQQGEwJVUzEVMBMGA1UEChMMVGhhd3RlLCBJbmMuMRYwFAYDVQQDEw1UaGF3dGUgU1NMIENBMB4XDTExMTI" + 
                "yMDAwMDAwMFoXDTE0MDIxNzIzNTk1OVowgYsxCzAJBgNVBAYTAlVTMREwDwYDVQQIEwhNYXJ5bGFuZDEUMBIGA1UEBxQLRm9yZXN0IEhpbGwxIzAhBgNVBAoUGkFwYWNoZSBTb2Z0d2FyZSBGb3VuZGF0aW" +
                "9uMRcwFQYDVQQLFA5JbmZyYXN0cnVjdHVyZTEVMBMGA1UEAxQMKi5hcGFjaGUub3JnMIICIjANBgkqhkiG9w0BAQEFAAOCAg8AMIICCgKCAgEApyhxElzdnWks7MMCEx24FMhHCbFcgKbO+fh/+JYrV91Cs" +
                "xsdqsAsvAU37P/eLMQ3ZVm93c6uQbt6cq+0VXniviFjXS3qUUJVUC60Q/YDzaYrTFZdY8ccA5wWdFTiMlJgwIqdlvB7JLkOzotvawRfJxeH+aucY756TdYGapAyno+3pWNXnU5sr1oaJ4uGchaS7LUAqpfP" +
                "fA3oTv63ZmIzHh2MTfDeUgdVSxeqEj3FCObLdps4Fs6c08Re2KAEZ+0UcMwNyJh0y6aP6PBgZAdt3qODONrI56TCDxjMC47lmIrm/U2Vy+v1LB90uU/1ESAiKvIKLjVZucO0U4Ol8VgiSDIH1FezXEhl+fP" + 
                "zY1N18u6kMx0AGDKDO0fBkUpkA6r6K4Kk/YvEJBLiIvLwLLnQhcwJjhRZItA52dNvKHMRYh5er1xVbLj7X+ujDfA6RpJYOmmPUxYzsZpZhTk0wybuGrkuvrm5t9ONP4p/2lan1G9aXqK6OLNh4W9IVUs1o1" +
                "KvMP86ToBOsZY/g50cld0kh7AMR+W/Lg9WtPxs1nq98k2J7HZBmMnYTEqwzSFtsMzGlqcFXO170JnfgklUjzi12vwQYO0bf/q+3e7QQsYRXzSGUEdKJZvzs0P09jJ6W/mDdnMdaoh7eYP5eynleZtElUgcd" +
                "NNgVAHn8NEUnJpwbGUCAwEAAaOBoDCBnTAMBgNVHRMBAf8EAjAAMDoGA1UdHwQzMDEwL6AtoCuGKWh0dHA6Ly9zdnItb3YtY3JsLnRoYXd0ZS5jb20vVGhhd3RlT1YuY3JsMB0GA1UdJQQWMBQGCCsGAQUF" +
                "BwMBBggrBgEFBQcDAjAyBggrBgEFBQcBAQQmMCQwIgYIKwYBBQUHMAGGFmh0dHA6Ly9vY3NwLnRoYXd0ZS5jb20wDQYJKoZIhvcNAQEFBQADggEBAA6BnlWlsAXvTmDpqijPpBUkD9Xkbys7UC/FOuUVr3P" +
                "K3d3GCQynwhooBe2CAshtxjb3Cc8zJfeqb5IQfjTcuEznIpONvqFvSmU4/INS+3/TPLoyQ81wpsIUbJzhhJY78CH8TZ5cn2BtWkI9fEydAXYe9a64GVdjPBJhneBon3J63s895GSSucQAIQZEiXBAqoklS5" +
                "n0Ud2aSYrNZJUVN3o8Rh0tvd0W2l6KjBaIZLUTieDZb3eRrValvjYDcCp9uI3aTdhht6zxUuE+OZ7DPWIWz3EYTMVTTtQdojJK9mM++JC74Y4s+JSCgRzTn3CxDMWPG5FWxavENub0FfsXfnY="));
			X509Certificate2 intermediateCA = new X509Certificate2(
            Convert.FromBase64String(
                "MIIEbDCCA1SgAwIBAgIQTV8sNAiyTCDNbVB+JE3J7DANBgkqhkiG9w0BAQUFADCBqTELMAkGA1UEBhMCVVMxFTATBgNVBAoTDHRoYXd0ZSwgSW5jLjEoMCYGA1UECxMfQ2VydGlmaWNhdGlvbiBTZXJ2aWN" + 
                "lcyBEaXZpc2lvbjE4MDYGA1UECxMvKGMpIDIwMDYgdGhhd3RlLCBJbmMuIC0gRm9yIGF1dGhvcml6ZWQgdXNlIG9ubHkxHzAdBgNVBAMTFnRoYXd0ZSBQcmltYXJ5IFJvb3QgQ0EwHhcNMTAwMjA4MDAwMD" + 
                "AwWhcNMjAwMjA3MjM1OTU5WjA8MQswCQYDVQQGEwJVUzEVMBMGA1UEChMMVGhhd3RlLCBJbmMuMRYwFAYDVQQDEw1UaGF3dGUgU1NMIENBMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAmeSFW" + 
                "3ZJfS8F2MWsyMip09yY5tc0pi8M8iIm2KPJFEyPBaRF6BQMWJAFGrfFwQalgK+7HUlrUjSIw1nn72vEJ0GMK2Yd0OCjl5gZNEtB1ZjVxwWtouTX7QytT8G1sCH9PlBTssSQ0NQwZ2ya8Q50xMLciuiX/8mS" + 
                "rgGKVgqYMrAAI+yQGmDD7bs6yw9jnw1EyVLhJZa/7VCViX9WFLG3YR0cB4w6LPf/gN45RdWvGtF42MdxaqMZpzJQIenyDqHGEwNESNFmqFJX1xG0k4vlmZ9d53hR5U32t1m0drUJN00GOBN6HAiYXMRISst" + 
                "SoKn4sZ2Oe3mwIC88lqgRYke7EQIDAQABo4H7MIH4MDIGCCsGAQUFBwEBBCYwJDAiBggrBgEFBQcwAYYWaHR0cDovL29jc3AudGhhd3RlLmNvbTASBgNVHRMBAf8ECDAGAQH/AgEAMDQGA1UdHwQtMCswKa" + 
                "AnoCWGI2h0dHA6Ly9jcmwudGhhd3RlLmNvbS9UaGF3dGVQQ0EuY3JsMA4GA1UdDwEB/wQEAwIBBjAoBgNVHREEITAfpB0wGzEZMBcGA1UEAxMQVmVyaVNpZ25NUEtJLTItOTAdBgNVHQ4EFgQUp6KDuzRFQ" + 
                "D381TBPErk+oQGf9tswHwYDVR0jBBgwFoAUe1tFz6/Oy3r9MZIaarbzRutXSFAwDQYJKoZIhvcNAQEFBQADggEBAIAigOBsyJUW11cmh/NyNNvGclYnPtOW9i4lkaU+M5enS+Uv+yV9Lwdh+m+DdExMU3Ig" + 
                "pHrPUVFWgYiwbR82LMgrsYiZwf5Eq0hRfNjyRGQq2HGn+xov+RmNNLIjv8RMVR2OROiqXZrdn/0Dx7okQ40tR0Tb9tiYyLL52u/tKVxpEvrRI5YPv5wN8nlFUzeaVi/oVxBw9u6JDEmJmsEj9cIqzEHPIqt" + 
                "lbreUgm0vQF9Y3uuVK6ZyaFIZkSqudZ1OkubK3lTqGKslPOZkpnkfJn1h7X3S5XFV2JMXfBQ4MDzfhuNMrUnjl1nOG5srztxl1Asoa06ERlFE9zMILViXIa4="));
    X509Chain chain = new X509Chain();
    chain.ChainPolicy.ExtraStore.Add(intermediateCA);
    chain.Build(endCert); // Whole chain!
    X509Certificate2 fMainCertificate = null;
    X509Certificate2Collection fExtraCertificates = new X509Certificate2Collection();
    fMainCertificate = endCert;
    fExtraCertificates.Add(intermediateCA);
    X509Store lStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);
    // No need to write to the user's store, just read.
    lStore.Open(OpenFlags.ReadOnly);
    try
    {
        List<X509Certificate2> lAddedCertificates = new List<X509Certificate2>();
        try
	{
	    foreach (X509Certificate2 lCertificate in fExtraCertificates)
	
            if (!lStore.Certificates.Contains(lCertificate))
	    {
	        lStore.Add(lCertificate);
                lAddedCertificates.Add(lCertificate);
            }
            X509Certificate2UI.DisplayCertificate(fMainCertificate);
	}
        finally
	{
	    foreach (X509Certificate2 lCertificate in lAddedCertificates)
	    lStore.Remove(lCertificate);
	}
    }
    finally { lStore.Close(); }
