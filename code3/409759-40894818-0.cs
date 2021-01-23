    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace System.Security.Cryptography.X509Certificates
    {
        public static class X509Certificate2Extensions
        {
            /// <summary>
            /// Returns an array of CRL distribution points for X509Certificate2 object.
            /// </summary>
            /// <param name="certificate">X509Certificate2 object.</param>
            /// <returns>Array of CRL distribution points.</returns>
            public static string[] GetCrlDistributionPoints(this X509Certificate2 certificate)
            {
                X509Extension ext = certificate.Extensions.Cast<X509Extension>().FirstOrDefault(
                    e => e.Oid.Value == "2.5.29.31");
                if (ext == null || ext.RawData == null || ext.RawData.Length < 11)
                    return EmptyStrings;
                int prev = -2;
                List<string> items = new List<string>();
                while (prev != -1 && ext.RawData.Length > prev + 1)
                {
                    int next = IndexOf(ext.RawData, 0x86, prev == -2 ? 8 : prev + 1);
                    if (next == -1)
                    {
                        if (prev >= 0)
                        {
                            string item = Encoding.UTF8.GetString(ext.RawData, prev + 2, ext.RawData.Length - (prev + 2));
                            items.Add(item);
                        }
                        break;
                    }
                    if (prev >= 0 && next > prev)
                    {
                        string item = Encoding.UTF8.GetString(ext.RawData, prev + 2, next - (prev + 2));
                        items.Add(item);
                    }
                    prev = next;
                }
                return items.ToArray();
            }
            static int IndexOf(byte[] instance, byte item, int start)
            {
                for (int i = start, l = instance.Length; i < l; i++)
                    if (instance[i] == item)
                        return i;
                return -1;
            }
            static string[] EmptyStrings = new string[0];
        }
    }
