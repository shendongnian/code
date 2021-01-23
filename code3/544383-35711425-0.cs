    using System;
    using System.Text;
    using System.Net;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading;
    
    namespace TestSecurity
    {
        class TestDownload
        {
            private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
            {
                //Progress in the download
            }
    
            private void client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
            {
                //Download has completed
            }
    
            private bool client_RemoteCertificateValidation(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                if (sslPolicyErrors == SslPolicyErrors.RemoteCertificateChainErrors)
                {
                    //Check to make sure the domain is correct
                    X509Certificate2 certificate_details = (X509Certificate2)certificate;
                    if (certificate_details.Thumbprint == "91A92CA60555DB51BEDDFE1AE4ECE54C8EBEBA97")
                    {
                        #region Fingerprint for certificate
                        string storedFingerprint = "" +
                        "42048c788db687ed84407da10f78182e3487d1fc31c07ee131151f4e19b360ad2a8c452c2e7d614a5691d5479787fe70dabd" +
                        "64617465732e626c75656172726f77646576656c6f706d656e742e636f6d3110300e06035504080c0747656f72676961311f" +
                        "301d060355040a0c16426c7565204172726f7720446576656c6f706d656e74310b3009060355040613025553312f302d0609" +
                        "2a864886f70d0109011620737570706f727440626c75656172726f77646576656c6f706d656e742e636f6d31123010060355" +
                        "04070c09436c6576656c616e64301e170d3136303232393231313733335a170d3137303232383231313733335a3081b03129" +
                        "302706035504030c20757064617465732e626c75656172726f77646576656c6f706d656e742e636f6d3110300e0603550408" +
                        "42048c788db687ed84407da10f78182e3487d1fc31c07ee131151f4e19b360ad2a8c452c2e7d614a5691d5479787fe70dabd" +
                        "0613025553312f302d06092a864886f70d0109011620737570706f727440626c75656172726f77646576656c6f706d656e74" +
                        "2e636f6d3112301006035504070c09436c6576656c616e6430820122300d06092a864886f70d01010105000382010f003082" +
                        "010a0282010100a1cdf5af6f1bba5cc8495d8061895f39858fde814f5581266505bf4cbe0b26506278bc247963bb7c42f0b8" +
                        "b00638871932ed7d0a3c6562be8e5b513f24da2768051acde875b53bf94c8ea2cec397145db206b2524c42a2019a0bfa14e2" +
                        "a7ef0d311235e07b7e0363345fd7f397e365c0865b1b8fa8ad7eebdc1fcdce360db04f2822438621534ae10744155a710641" +
                        "9a69c16745974a37c5b06917036351b92c06540a6c70aa776c143eef6f7b8ec31c0c40a9eab8a399c9065bea688ea7bd1db2" +
                        "30af56d2ca0f8983f9e8dacb5613755fbcd8229d7042668a9130468a7480a2afde8c18bab895472ddf1ed2c49291c04e8cc2" +
                        "ff24db33d231b3a2498c03a5650203010001a34d304b301d0603551d0e0416041476b5c2c82ff138b87c0e2d6c046af4c634" +
                        "55040a0c16426c75652048c1f54dcb82e3487d1fc31c07ee1313fba9204c7b3232ba9204c7b323a021abcbda85bfca9c9931" +
                        "092a864886f70d01010b050003820101001ab0dfd318cc2e93a997445d0950ffcb63544c58fe1ded6e234aa7ccdcb5c890b1" +
                        "61b51ae08c1f54dcb3fbeca9c9932bde91d202b89c0b6f0af1a370017fa9f6a021abcbda85bfecebebc6d6067d4dc1e51ec5" +
                        "02cf95867516a84f01410cf80d7af4f0d3e9a86cf7b0323dba9204c7b3232c58b2289032a12aaa1ec4f64065da8bbde4fe47" +
                        "42048c788db687ed84407da10f78182e3487d1fc31c07ee131151f4e19b360ad2a8c452c2e7d614a5691d5479787fe70dabd" +
                        "de819522bb7ef870595d9738a6acdd39b7fcf6f36948ef2b404c2b6d7ebe577555148ad90013a5c2e812b2b907c808288040" +
                        "0db6702407585328f7e6c84b40451384391783001174d0";
                        #endregion
    
                        //Use the following to get the server's fingerprint to be saved and compared against
                        StringBuilder hex = new StringBuilder(certificate_details.RawData.Length * 2);
                        foreach (byte b in certificate_details.RawData)
                            hex.AppendFormat("{0:x2}", b);
                        string serverFingerprint = hex.ToString();
    
                        if (serverFingerprint == storedFingerprint) return true;
                        else return false;
                    }
                    else return false;
                }
                else if (sslPolicyErrors == SslPolicyErrors.None)
                    return true;
                else
                    return false;
            }
    
            public void TestDownload(Uri targetURL, bool useCredentials, string user, string pass)
            {
                WebClient client = new WebClient();
                bool taskCompleted = false;
    
                //Create the event handlers to monitor progress
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadDataCompleted += new DownloadDataCompletedEventHandler(client_DownloadDataCompleted);
                ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(client_RemoteCertificateValidation);
    
                //Resolve the host
                IPHostEntry host = Dns.GetHostEntry(targetURL.Host);
                IPAddress ip = (host.AddressList.Length > 0 ? host.AddressList[0] : null);
    
                //Show the UI the resolved host
    
                //Account for credentials
                if (useCredentials)
                {
                    NetworkCredential credentials = new NetworkCredential(
                        user,
                        pass);
                    client.Credentials = credentials;
                }
                else client.Credentials = null;
    
                //Download file
                client.DownloadDataAsync(targetURL, taskCompleted);
    
                //Go to sleep until the file download has completed
                do { Thread.Sleep(500); } while (client.IsBusy);
    
                //File download complete
    
                //Destory the event handlers as they are no longer needed
                ServicePointManager.ServerCertificateValidationCallback -= client_RemoteCertificateValidation;
                client.DownloadProgressChanged -= client_DownloadProgressChanged;
                client.DownloadDataCompleted -= client_DownloadDataCompleted;
            }
        }
    }
