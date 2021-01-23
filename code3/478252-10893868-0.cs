            var chars = new byte[] {32,160,164 };
            var enc=Encoding.GetEncoding(1256);
            var str=enc.GetString(chars);
            foreach (var character in str)
            {
                Console.WriteLine("{0}:{1}", character, Char.IsWhiteSpace(character));
            }
            Console.ReadKey();
