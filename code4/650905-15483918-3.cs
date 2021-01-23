            var publishSettingsFile =
            @"C:\yourPublishSettingsFilePathGoesHere";
            XDocument xdoc = XDocument.Load(publishSettingsFile);
            var managementCertbase64string =
                xdoc.Descendants("PublishProfile").Single().Attribute("ManagementCertificate").Value;
            var managementCert = new X509Certificate2(
                Convert.FromBase64String(managementCertbase64string));
            // If you have more than one subscription, you'll need to change this
            string subscriptionId = xdoc.Descendants("Subscription").First().Attribute("Id").Value;
            string desiredStorageService = "yourStorageServiceName";
            var req = (HttpWebRequest)WebRequest.Create(
                string.Format("https://management.core.windows.net/{0}/services/storageservices/{1}/keys",
                                                subscriptionId,
                                                desiredStorageService));
            req.Headers["x-ms-version"] = "2012-08-01";
            req.ClientCertificates.Add(managementCert);
            XNamespace xmlns = "http://schemas.microsoft.com/windowsazure";
            XDocument response = XDocument.Load(req.GetResponse().GetResponseStream());
            Console.WriteLine("Primary key: " + response.Descendants(xmlns + "Primary").First().Value);
            Console.WriteLine("Secondary key: " + response.Descendants(xmlns + "Secondary").First().Value);
            Console.Read();
