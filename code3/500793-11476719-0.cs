        static void Main(string[] args)
        {
            const string rawTrack = "6900460420006149231=13050010300100000";
            var byteList = new LinkedList<byte>();
            foreach (var c in rawTrack)
            {
                if(c.Equals('='))
                {
                    byteList.AddLast(13);
                    continue;
                }
                var bytes = Formatters.Bcd.GetBytes(new string(c, 1));  // for 9 gives 0x09
                byteList.AddLast(bytes[0]);
            }
            // Adjust Buffer if odd length
            if(rawTrack.Length % 2 != 0)
            {
                byteList.AddFirst(0);
            }
            var result = new byte[byteList.Count / 2];
            var buffer = new byte[byteList.Count];
            byteList.CopyTo(buffer, 0);
            var j = 0;
            for(var i = 0; i < buffer.Length - 1; i += 2, j++ )
            {
                result[j] = CombineLowNibble(buffer[i], buffer[i + 1]);
            }
            Console.WriteLine(BitConverter.ToString(result));
        }
        private static byte CombineLowNibble(byte b, byte b1)
        {
            return (byte) ((b << 4) | b1);
        }
