    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Collections;
    using System.IO;
    using Org.BouncyCastle.Asn1.X509;
    using Org.BouncyCastle.Asn1.Pkcs;
    using Org.BouncyCastle.Crypto.Digests;
    using Org.BouncyCastle.Crypto.Parameters;
    using Org.BouncyCastle.Crypto.Signers;
    using Org.BouncyCastle.X509;
    using Org.BouncyCastle.Math;
    using Org.BouncyCastle.Math.EC;
    using Org.BouncyCastle.Utilities.Collections;
    using Org.BouncyCastle.Utilities.Encoders;
    using Org.BouncyCastle.Crypto; 
    using Org.BouncyCastle.Crypto.Engines; 
    using Org.BouncyCastle.OpenSsl;
    /* 
    	For an Active Directory generated pem, strip out everything in pem file before line:
    	"-----BEGIN PRIVATE KEY-----" and re-save.
    */
    string privateKeyFileName = @"C:\CertificateTest\CS\bccrypto-net-1.7-bin\private_key3.pem";
    TextReader reader = File.OpenText(privateKeyFileName);
    Org.BouncyCastle.Crypto.Parameters.RsaPrivateCrtKeyParameters key;
    using (reader = File.OpenText(privateKeyFileName))
    {
    	key = (Org.BouncyCastle.Crypto.Parameters.RsaPrivateCrtKeyParameters)new PemReader(reader).ReadObject();
    }
    cipher.Init(false, key);
    //Decrypting the input bytes
    byte[] decipheredBytes = cipher.ProcessBlock(cipheredBytes, 0, cipheredBytes.Length);
    MessageBox.Show(Encoding.UTF8.GetString(decipheredBytes));
