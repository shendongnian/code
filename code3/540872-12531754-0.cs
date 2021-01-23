    System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                        byte[] d = encoding.GetBytes(str5[1]);
    var dest[] = new byte();
    var iCoun = 0;
    var iPowe = 1;
    foreach(var byte in d)
    {
      dest[i++] = (byte & iPowe);
      iPowe *= 2;
    }
    foreach(var byte in dest)
    {
      Console.WriteLine(byte);
    }
