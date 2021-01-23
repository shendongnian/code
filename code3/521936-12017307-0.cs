    using System;
    using System.IO;
    using MiscUtil.Conversion;
    using MiscUtil.IO;
    
    static class Test
    {
        static void Main()
        {
            using (var stream = File.OpenRead("myfile.bin"))
            {
                var converter = new BigEndianBitConverter();
                var reader = new EndianBinaryReader(converter, stream);
                Console.WriteLine(reader.ReadInt16());
            }
        } 
    }
