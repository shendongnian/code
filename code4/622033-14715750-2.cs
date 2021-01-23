          var reader = new BinaryReader(new MemoryStream(byteArray), Encoding.ASCII);
          while (reader.BaseStream.Position < reader.BaseStream.Length)
          {
            switch(reader.ReadChar())
            {
              case 'A':
                {
                  var i = reader.ReadInt32();
                  return new TypeA(i);
                }
                break;
              case 'B':
                {
                  var i = reader.ReadByte();
                  return new TypeB(i);
                }
                break;
              case 'C':
                {
                  var chars = reader.ReadChars(49);
                  return new TypeC(new string(chars.TakeWhile(ch => ch != 0).ToArray()));
                }
                break;
            }
          }
