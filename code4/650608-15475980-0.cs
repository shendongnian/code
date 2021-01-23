         string data = " %04F%02%BC%94%BA%15%E3%AA%08%00%7FF%00";
         // You need to pick an encoding -- are these things ASCII?
         var encoding = Encoding.ASCII;
         var values = new List<byte>();
         // Walk over the data (note that we don't increment here).
         for (int i = 0; i < data.Length;)
         {
            // Is this the start of an escaped byte?
            if (data[i] == '%')
            {
               // Grab the two characters after the '%'.
               var escaped = data.Substring(i + 1, 2);
               //Console.WriteLine(escaped);
               // Convert them to a byte.
               byte value = Convert.ToByte(escaped, 16);
               values.Add(value);
               // Increment over the three characters making up the escaped byte.
               i += 3;
            }
            else
            {
               // It's a non-escaped character.
               var plain = data[i];
               //Console.WriteLine(plain);
               // Convert it to a single byte.
               byte[] bytes = encoding.GetBytes(new[] { plain });
               Debug.Assert(bytes.Length == 1);
               byte value = bytes[0];
               values.Add(value);
               // Increment over that character.
               i += 1;
            }
         }
         // Print it out, in hex, separated by commas.
         Console.WriteLine(string.Join(", ",
                           values.Select(v => string.Format("{0:X2}", v))));
         // Alternatively...
         Console.WriteLine(BitConverter.ToString(values.ToArray()));
