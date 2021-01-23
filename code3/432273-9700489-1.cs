    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SqlTypes;
    using Microsoft.SqlServer.Server;
    using System.IO;
    using System.Text;
    using System.Security.Cryptography;
    
    public partial class UserDefinedFunctions
    {
        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlBinary Cifrar(string dato, string clave, string vectorInicial)
        {
            byte[] plainText = Encoding.ASCII.GetBytes(dato);
            byte[] keys = Encoding.ASCII.GetBytes(clave);
            byte[] vecI = Encoding.ASCII.GetBytes(vectorInicial);
            MemoryStream memdata = new MemoryStream();
    
    
            RC2CryptoServiceProvider rc2 = new RC2CryptoServiceProvider();
            ICryptoTransform transform;
            rc2.Mode = CipherMode.CBC;
            transform = rc2.CreateEncryptor(keys, vecI);
    
            CryptoStream encStream = new CryptoStream(memdata, transform, CryptoStreamMode.Write);
    
    
            encStream.Write(plainText, 0, plainText.Length);
            encStream.Close();
            return new SqlBinary(memdata.ToArray());
        }
    
        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlString Descrifrar(byte[] dato, string clave, string vectorInicial)
        {
            byte[] keys = Encoding.ASCII.GetBytes(clave);
            byte[] vecI = Encoding.ASCII.GetBytes(vectorInicial);
            MemoryStream memdata = new MemoryStream();
    
            RC2CryptoServiceProvider rc2 = new RC2CryptoServiceProvider();
            ICryptoTransform transform;
            rc2.Mode = CipherMode.CBC;
            transform = rc2.CreateDecryptor(keys, vecI);
    
            CryptoStream encStream = new CryptoStream(memdata, transform, CryptoStreamMode.Write);
    
    
            encStream.Write(dato, 0, dato.Length);
            encStream.Close();
    
            return new SqlString(Encoding.ASCII.GetString(memdata.ToArray()));
        }
    };
