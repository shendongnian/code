    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Collections;
    using System.Threading;
    using System.Security;
    using System.Security.Cryptography;
    using System.Net;
    using System.Net.Sockets;
    
    namespace EncryptionTestA
    {
        class Program
        {
            static void Main(string[] args)
            {
                TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 1892);
                listener.Start();
                TcpClient client = listener.AcceptTcpClient();
                NetworkStream ns = client.GetStream();
    
                Rijndael aes = RijndaelManaged.Create();
                byte[] key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
                byte[] iv = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
                aes.Key = key;
                aes.IV = iv;
    
                byte[] message = Program.ReadMessage(ns, aes);
                String output = System.Text.Encoding.UTF8.GetString(message);
                Console.WriteLine(output);
    
                Console.Read();
    
                ns.Close();
                client.Close();
                listener.Stop();
            }
    
            static byte[] ReadMessage(NetworkStream stream, Rijndael aes)
            {
                if (stream.CanRead)
                {
                    byte[] buffer = new byte[4096];
    
                    MemoryStream ms = new MemoryStream(4096);
                    CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write);
                    do
                    {
                        int length = stream.Read(buffer, 0, buffer.Length);
                        cs.Write(buffer, 0, length);
                    } while (stream.DataAvailable);
    
                    cs.Close();
                    return ms.ToArray();
                }
                else
                {
                    return new byte[0];
                }
            }
        }
    }
----------
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Collections;
    using System.Threading;
    using System.Security;
    using System.Security.Cryptography;
    using System.Net;
    using System.Net.Sockets;
    
    namespace EncryptionTestB
    {
        class Program
        {
            static void Main(string[] args)
            {
                TcpClient client = new TcpClient();
                client.Connect(IPAddress.Parse("127.0.0.1"), 1892);
                NetworkStream ns = client.GetStream();
    
                Rijndael aes = RijndaelManaged.Create();
                byte[] key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
                byte[] iv = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
                aes.Key = key;
                aes.IV = iv;
    
                Program.SendMessage("hello world!\n", ns, aes);
    
                Console.Read();
    
                ns.Close();
                client.Close();
            }
    
            static void SendMessage(String message, NetworkStream stream, Rijndael aes)
            {
                byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(message);
                Program.SendMessage(messageBytes, stream, aes);
            }
    
            static void SendMessage(byte[] message, NetworkStream stream, Rijndael aes)
            {
                if (stream.CanWrite)
                {
                    MemoryStream ms = new MemoryStream(4096);
                    CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
    
                    cs.Write(message, 0, message.Length);
                    cs.Close();
    
                    byte[] cipherText = ms.ToArray();
                    stream.Write(cipherText, 0, cipherText.Length);
                }
                else
                {
                    Console.WriteLine("Error:  Stream is not valid for writing.\n");
                }
            }
        }
    }
