    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    
    namespace MyNamespace
    {
        public static class SecurityShower
        {
            public static void ShowHttpWebRequest(System.Net.HttpWebRequest hwr)
            {
                StringBuilder sb = new StringBuilder();
                if (null != hwr)
                {
                    sb.Append("-----------------------------------------------HttpWebRequest" + System.Environment.NewLine);
                    sb.Append(string.Format("HttpWebRequest.Address.AbsolutePath='{0}'", hwr.Address.AbsolutePath) + System.Environment.NewLine);
                    sb.Append(string.Format("HttpWebRequest.Address.AbsoluteUri='{0}'", hwr.Address.AbsoluteUri) + System.Environment.NewLine);
                    sb.Append(string.Format("HttpWebRequest.Address='{0}'", hwr.Address) + System.Environment.NewLine);
    
                    sb.Append(string.Format("HttpWebRequest.RequestUri.AbsolutePath='{0}'", hwr.RequestUri.AbsolutePath) + System.Environment.NewLine);
                    sb.Append(string.Format("HttpWebRequest.RequestUri.AbsoluteUri='{0}'", hwr.RequestUri.AbsoluteUri) + System.Environment.NewLine);
                    sb.Append(string.Format("HttpWebRequest.RequestUri='{0}'", hwr.RequestUri) + System.Environment.NewLine);
    
                    foreach (X509Certificate cert in hwr.ClientCertificates)
                    {
                        sb.Append("START*************************************************");
                        ShowX509Certificate(sb, cert);
                        sb.Append("END*************************************************");
                    }
                }
    
                string result = sb.ToString();
                Console.WriteLine(result);
            }
    
            public static void ShowCertAndChain(X509Certificate2 cert)
            {
                X509Chain chain = new X509Chain();
                chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
                chain.ChainPolicy.RevocationMode = X509RevocationMode.Offline;
                chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
    
                ////chain.ChainPolicy.VerificationFlags = X509VerificationFlags.IgnoreCtlSignerRevocationUnknown &&
                ////X509VerificationFlags.IgnoreRootRevocationUnknown &&
                ////X509VerificationFlags.IgnoreEndRevocationUnknown &&
                ////X509VerificationFlags.IgnoreCertificateAuthorityRevocationUnknown &&
                ////X509VerificationFlags.IgnoreCtlNotTimeValid;
    
                chain.Build(cert);
    
                ShowCertAndChain(cert, chain);
            }
    
            public static void ShowCertAndChain(X509Certificate cert, X509Chain chain)
            {
                StringBuilder sb = new StringBuilder();
                if (null != cert)
                {
                    ShowX509Certificate(sb, cert);
                }
    
                if (null != chain)
                {
                    sb.Append("-X509Chain(Start)-" + System.Environment.NewLine);
                    ////sb.Append(string.Format("Cert.ChainStatus='{0}'", string.Join(",", chain.ChainStatus.ToList())) + System.Environment.NewLine);
    
                    foreach (X509ChainStatus cstat in chain.ChainStatus)
                    {
                        sb.Append(string.Format("X509ChainStatus::'{0}'-'{1}'", cstat.Status.ToString(), cstat.StatusInformation) + System.Environment.NewLine);
                    }
    
                    X509ChainElementCollection ces = chain.ChainElements;
                    ShowX509ChainElementCollection(sb, ces);
                    sb.Append("-X509Chain(End)-" + System.Environment.NewLine);
                }
    
                string result = sb.ToString();
                Console.WriteLine(result);
            }
    
            private static void ShowX509Extension(StringBuilder sb, int x509ExtensionCount, X509Extension ext)
            {
                sb.Append(string.Empty + System.Environment.NewLine);
                sb.Append(string.Format("--------X509ExtensionNumber(Start):{0}", x509ExtensionCount) + System.Environment.NewLine);
                sb.Append(string.Format("X509Extension.Critical='{0}'", ext.Critical) + System.Environment.NewLine);
    
                AsnEncodedData asndata = new AsnEncodedData(ext.Oid, ext.RawData);
                sb.Append(string.Format("Extension type: {0}", ext.Oid.FriendlyName) + System.Environment.NewLine);
                sb.Append(string.Format("Oid value: {0}", asndata.Oid.Value) + System.Environment.NewLine);
                sb.Append(string.Format("Raw data length: {0} {1}", asndata.RawData.Length, Environment.NewLine) + System.Environment.NewLine);
                sb.Append(asndata.Format(true) + System.Environment.NewLine);
    
                X509BasicConstraintsExtension basicEx = ext as X509BasicConstraintsExtension;
                if (null != basicEx)
                {
                    sb.Append("-X509BasicConstraintsExtension-" + System.Environment.NewLine);
                    sb.Append(string.Format("X509Extension.X509BasicConstraintsExtension.CertificateAuthority='{0}'", basicEx.CertificateAuthority) + System.Environment.NewLine);
                }
    
                X509EnhancedKeyUsageExtension keyEx = ext as X509EnhancedKeyUsageExtension;
                if (null != keyEx)
                {
                    sb.Append("-X509EnhancedKeyUsageExtension-" + System.Environment.NewLine);
                    sb.Append(string.Format("X509Extension.X509EnhancedKeyUsageExtension.EnhancedKeyUsages='{0}'", keyEx.EnhancedKeyUsages) + System.Environment.NewLine);
                    foreach (Oid oi in keyEx.EnhancedKeyUsages)
                    {
                        sb.Append(string.Format("------------EnhancedKeyUsages.Oid.FriendlyName='{0}'", oi.FriendlyName) + System.Environment.NewLine);
                        sb.Append(string.Format("------------EnhancedKeyUsages.Oid.Value='{0}'", oi.Value) + System.Environment.NewLine);
                    }
                }
    
                X509KeyUsageExtension usageEx = ext as X509KeyUsageExtension;
                if (null != usageEx)
                {
                    sb.Append("-X509KeyUsageExtension-" + System.Environment.NewLine);
                    sb.Append(string.Format("X509Extension.X509KeyUsageExtension.KeyUsages='{0}'", usageEx.KeyUsages) + System.Environment.NewLine);
                    sb.Append(string.Format("X509KeyUsageExtension.KeyUsages.X509KeyUsageFlags.CrlSign='{0}'", (usageEx.KeyUsages & X509KeyUsageFlags.CrlSign) != 0) + System.Environment.NewLine);
                    sb.Append(string.Format("X509KeyUsageExtension.KeyUsages.X509KeyUsageFlags.DataEncipherment='{0}'", (usageEx.KeyUsages & X509KeyUsageFlags.DataEncipherment) != 0) + System.Environment.NewLine);
                    sb.Append(string.Format("X509KeyUsageExtension.KeyUsages.X509KeyUsageFlags.DecipherOnly='{0}'", (usageEx.KeyUsages & X509KeyUsageFlags.DecipherOnly) != 0) + System.Environment.NewLine);
                    sb.Append(string.Format("X509KeyUsageExtension.KeyUsages.X509KeyUsageFlags.DigitalSignature='{0}'", (usageEx.KeyUsages & X509KeyUsageFlags.DigitalSignature) != 0) + System.Environment.NewLine);
                    sb.Append(string.Format("X509KeyUsageExtension.KeyUsages.X509KeyUsageFlags.EncipherOnly='{0}'", (usageEx.KeyUsages & X509KeyUsageFlags.EncipherOnly) != 0) + System.Environment.NewLine);
                    sb.Append(string.Format("X509KeyUsageExtension.KeyUsages.X509KeyUsageFlags.KeyAgreement='{0}'", (usageEx.KeyUsages & X509KeyUsageFlags.KeyAgreement) != 0) + System.Environment.NewLine);
                    sb.Append(string.Format("X509KeyUsageExtension.KeyUsages.X509KeyUsageFlags.KeyCertSign='{0}'", (usageEx.KeyUsages & X509KeyUsageFlags.KeyCertSign) != 0) + System.Environment.NewLine);
                    sb.Append(string.Format("X509KeyUsageExtension.KeyUsages.X509KeyUsageFlags.KeyEncipherment='{0}'", (usageEx.KeyUsages & X509KeyUsageFlags.KeyEncipherment) != 0) + System.Environment.NewLine);
                    sb.Append(string.Format("X509KeyUsageExtension.KeyUsages.X509KeyUsageFlags.None='{0}'", (usageEx.KeyUsages & X509KeyUsageFlags.None) != 0) + System.Environment.NewLine);
                    sb.Append(string.Format("X509KeyUsageExtension.KeyUsages.X509KeyUsageFlags.NonRepudiation='{0}'", (usageEx.KeyUsages & X509KeyUsageFlags.NonRepudiation) != 0) + System.Environment.NewLine);
                }
    
                X509SubjectKeyIdentifierExtension skIdEx = ext as X509SubjectKeyIdentifierExtension;
                if (null != skIdEx)
                {
                    sb.Append("-X509SubjectKeyIdentifierExtension-" + System.Environment.NewLine);
                    sb.Append(string.Format("X509Extension.X509SubjectKeyIdentifierExtension.Oid='{0}'", skIdEx.Oid) + System.Environment.NewLine);
                    sb.Append(string.Format("X509Extension.X509SubjectKeyIdentifierExtension.SubjectKeyIdentifier='{0}'", skIdEx.SubjectKeyIdentifier) + System.Environment.NewLine);
                }
    
                sb.Append(string.Format("--------X509ExtensionNumber(End):{0}", x509ExtensionCount) + System.Environment.NewLine);
            }
    
            private static void ShowX509Extensions(StringBuilder sb, string cert2SubjectName, X509ExtensionCollection extColl)
            {
                int x509ExtensionCount = 0;
                sb.Append(string.Format("--------ShowX509Extensions(Start):for:{0}", cert2SubjectName) + System.Environment.NewLine);
                foreach (X509Extension ext in extColl)
                {
                    ShowX509Extension(sb, ++x509ExtensionCount, ext);
                }
    
                sb.Append(string.Format("--------ShowX509Extensions(End):for:{0}", cert2SubjectName) + System.Environment.NewLine);
            }
    
            private static void ShowX509Certificate2(StringBuilder sb, X509Certificate2 cert2)
            {
                if (null != cert2)
                {
                    sb.Append(string.Format("X509Certificate2.SubjectName.Name='{0}'", cert2.SubjectName.Name) + System.Environment.NewLine);
                    sb.Append(string.Format("X509Certificate2.Subject='{0}'", cert2.Subject) + System.Environment.NewLine);
                    sb.Append(string.Format("X509Certificate2.Thumbprint='{0}'", cert2.Thumbprint) + System.Environment.NewLine);
                    sb.Append(string.Format("X509Certificate2.HasPrivateKey='{0}'", cert2.HasPrivateKey) + System.Environment.NewLine);
                    sb.Append(string.Format("X509Certificate2.Version='{0}'", cert2.Version) + System.Environment.NewLine);
                    sb.Append(string.Format("X509Certificate2.NotBefore='{0}'", cert2.NotBefore) + System.Environment.NewLine);
                    sb.Append(string.Format("X509Certificate2.NotAfter='{0}'", cert2.NotAfter) + System.Environment.NewLine);
                    sb.Append(string.Format("X509Certificate2.PublicKey.Key.KeySize='{0}'", cert2.PublicKey.Key.KeySize) + System.Environment.NewLine);
    
                    ////List<X509KeyUsageExtension> keyUsageExtensions = cert2.Extensions.OfType<X509KeyUsageExtension>().ToList();
                    ////List<X509Extension> extensions = cert2.Extensions.OfType<X509Extension>().ToList();
    
                    ShowX509Extensions(sb, cert2.Subject, cert2.Extensions);
                }
            }
    
            private static void ShowX509ChainElementCollection(StringBuilder sb, X509ChainElementCollection ces)
            {
                int x509ChainElementCount = 0;
                foreach (X509ChainElement ce in ces)
                {
                    sb.Append(string.Empty + System.Environment.NewLine);
                    sb.Append(string.Format("----X509ChainElementNumber:{0}", ++x509ChainElementCount) + System.Environment.NewLine);
                    sb.Append(string.Format("X509ChainElement.Cert.SubjectName.Name='{0}'", ce.Certificate.SubjectName.Name) + System.Environment.NewLine);
                    sb.Append(string.Format("X509ChainElement.Cert.Issuer='{0}'", ce.Certificate.Issuer) + System.Environment.NewLine);
                    sb.Append(string.Format("X509ChainElement.Cert.Thumbprint='{0}'", ce.Certificate.Thumbprint) + System.Environment.NewLine);
                    sb.Append(string.Format("X509ChainElement.Cert.HasPrivateKey='{0}'", ce.Certificate.HasPrivateKey) + System.Environment.NewLine);
    
                    X509Certificate2 cert2 = ce.Certificate as X509Certificate2;
                    ShowX509Certificate2(sb, cert2);
    
                    ShowX509Extensions(sb, cert2.Subject, ce.Certificate.Extensions);
                }
            }
    
            private static void ShowX509Certificate(StringBuilder sb, X509Certificate cert)
            {
                sb.Append("-----------------------------------------------" + System.Environment.NewLine);
                sb.Append(string.Format("Cert.Subject='{0}'", cert.Subject) + System.Environment.NewLine);
                sb.Append(string.Format("Cert.Issuer='{0}'", cert.Issuer) + System.Environment.NewLine);
    
                sb.Append(string.Format("Cert.GetPublicKey().Length='{0}'", cert.GetPublicKey().Length) + System.Environment.NewLine);
    
                X509Certificate2 cert2 = cert as X509Certificate2;
                ShowX509Certificate2(sb, cert2);
            }
        }
    }
