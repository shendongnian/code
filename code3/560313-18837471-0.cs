    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.IO;
    namespace TrustCert
    {
        class Program
        {
            static void Main(string[] args)
            {
                string msg = "";
                try
                {
                    byte[] pfx;
                    var assembly = typeof(Program).Assembly;
                    string pfxName = "";
                    foreach (string mr in assembly.GetManifestResourceNames())
                    {
                        if (mr.Contains("MyPfxName"))
                        {
                            pfxName = mr;
                            break;
                        }
                    }
                    using (var stream = assembly.GetManifestResourceStream(pfxName))
                    {
                        pfx = new byte[stream.Length];
                        stream.Read(pfx, 0, pfx.Length);
                    }
                    X509Certificate2 cert = new X509Certificate2(pfx, "pfxPassword");
                    X509Store store = new X509Store(StoreName.TrustedPublisher
                        , StoreLocation.LocalMachine);
                    store.Open(OpenFlags.ReadWrite);
                    store.Add(cert);
                    store.Close();
                    msg = "Certificate installed";
                }
                catch (Exception e)
                {
                    msg = e.ToString();
                }
                Console.WriteLine(msg);
            }
        }
    }
