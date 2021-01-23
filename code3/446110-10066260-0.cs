    class Program {
        static void Main (string [] args)
        {
            byte[] src_ip = new byte[]
                                {
                                    0xfe, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                    0x02, 0x19, 0x55, 0xff, 0xfe, 0x27, 0x27, 0xd0
                                };
            byte[] dst_ip = new byte[]
                                {
                                    0xfe, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                    0x02, 0x22, 0x75, 0xff, 0xfe, 0xd6, 0xfe, 0x50
                                };
            byte[] length = new byte[] {0, 0, 0, 32};
            byte [] next = new byte [] { 0, 0, 0, 58 };
            byte[] payload = new byte[]
                                 {
                                     0x88, 0x00, 0xab, 0xa5, 0xe0, 0x00, 0x00, 0x00, 
                                     0xfe, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                     0x02, 0x19, 0x55, 0xff, 0xfe, 0x27, 0x27, 0xd0,
                                     0x02, 0x01, 0x00, 0x19, 0x55, 0x27, 0x27, 0xd0
                                 };
    #if true
            payload [2] = 0;
            payload [3] = 0;
    #endif
            ushort checksum = ICMPchecksum(src_ip, dst_ip, length, next, payload);
            Console.WriteLine (checksum.ToString ("X"));
            Console.ReadKey ();
        }
        public static ushort BitConverterToUInt16 (byte [] value, int startIndex)
        {
    #if false
                return System.BitConverter.ToUInt16 (value, startIndex);
    #else
                return System.BitConverter.ToUInt16 (value.Reverse ().ToArray (), value.Length - sizeof (UInt16) - startIndex);
    #endif
        }
        static ushort ICMPchecksum (byte [] src_ip, byte [] dst_ip, byte [] length, byte [] next, byte [] payload)
        {
            uint checksum = 0;
            //length of byte fields
            Console.WriteLine ("src_ip: " + src_ip.Length + " dst_ip: " + dst_ip.Length + " length: " + length.Length + " next_header: " + next.Length + " payload: " + payload.Length);
            //display all fields, which will be used for checksum calculation
            Console.WriteLine (BitConverter.ToString (src_ip));
            Console.WriteLine (BitConverter.ToString (dst_ip));
            Console.WriteLine (BitConverter.ToString (length));
            Console.WriteLine (BitConverter.ToString (next));
            Console.WriteLine (BitConverter.ToString (payload));
            //ADDS SOURCE IPv6 address
            checksum += BitConverterToUInt16 (src_ip, 0);
            checksum += BitConverterToUInt16 (src_ip, 2);
            checksum += BitConverterToUInt16 (src_ip, 4);
            checksum += BitConverterToUInt16 (src_ip, 6);
            checksum += BitConverterToUInt16 (src_ip, 8);
            checksum += BitConverterToUInt16 (src_ip, 10);
            checksum += BitConverterToUInt16 (src_ip, 12);
            checksum += BitConverterToUInt16 (src_ip, 14);
            //ADDS DEST IPv6 address
            checksum += BitConverterToUInt16 (dst_ip, 0);
            checksum += BitConverterToUInt16 (dst_ip, 2);
            checksum += BitConverterToUInt16 (dst_ip, 4);
            checksum += BitConverterToUInt16 (dst_ip, 6);
            checksum += BitConverterToUInt16 (dst_ip, 8);
            checksum += BitConverterToUInt16 (dst_ip, 10);
            checksum += BitConverterToUInt16 (dst_ip, 12);
            checksum += BitConverterToUInt16 (dst_ip, 14);
            //ADDS LENGTH OF ICMPv6 packet
            checksum += BitConverterToUInt16 (length, 0);
            checksum += BitConverterToUInt16 (length, 2);
            //ADDS NEXT HEADER ID = 58
            checksum += BitConverterToUInt16 (next, 0);
            checksum += BitConverterToUInt16 (next, 2);
            //ADDS WHOLE ICMPv6 message
            for (int i = 0; i < payload.Length; i = i + 2) {
                Console.WriteLine (i);
                checksum += BitConverterToUInt16 (payload, i);
            }
            checksum += (ushort)(checksum >> 16);
            return (ushort)~checksum;
        }
    }
