    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace FourCC
    {
        class Program
        {
            static void Main(string[] args)
            {
                string fourCC = "YUY2";
    
                Console.WriteLine("Big endian value of {0} is {1}", fourCC, ConvertFourCC(fourCC, toBigEndian:true));
                Console.WriteLine("Little endian value of {0} is {1}", fourCC, ConvertFourCC(fourCC));
                Console.WriteLine("GUID value of {0} is {1}", fourCC, ConvertFourCC(fourCC, toGuid:true));
                Console.ReadKey();
    
            }
    
            static string ConvertFourCC(string fourCC, bool toBigEndian = false, bool toGuid = false)
            {
                if (!String.IsNullOrWhiteSpace(fourCC))
                {
                    if (fourCC.Length != 4)
                    {
                        throw new FormatException("FOURCC length must be four characters");                    
                    }
                    else
                    {
                        char[] c = fourCC.ToCharArray();
    
                        if (toBigEndian)
                        {
                            return String.Format("{0:X}", (c[0] << 24| c[1] << 16 | c[2] << 8 | c[3]));
                        }
                        else if (toGuid)
                        {
                            return String.Format("{0:X}", (c[3] << 24) | (c[2] << 16) | (c[1] << 8) | c[0]) + "-0000-0010-8000-00AA00389B71";
                        }
                        else
                        {
                            return String.Format("{0:X}", (c[3] << 24) | (c[2] << 16) | (c[1] << 8) | c[0]);
                        }
                    }
                }
                return null;
            }
        }
    }
