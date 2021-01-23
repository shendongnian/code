          strPhoto = csvuser.photo; // The string that represents the BLOB
          //remove first 2 chars (the '0x')
          strPhoto = strPhoto.Remove(0, 2);
          //convert hex-string to bytes:
          int NumberChars = strPhoto.Length/2;
          byte[] bytes = new byte[NumberChars];
          using (StringReader sr = new StringReader(strPhoto)){
                for (int i = 0; i < NumberChars; i++)
                   bytes[i] = Convert.ToByte(new string(new char[2]{(char)sr.Read(), (char)sr.Read()}), 16);
          }
     
          // Then we create a memory stream that holds the image
          MemoryStream photostream = new MemoryStream( bytes );
    
          // Then we can create a System.Drawing.Image by using the Memory stream
          var photo = Image.FromStream(photostream);
