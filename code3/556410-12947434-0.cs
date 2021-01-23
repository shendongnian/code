    private string ReadData(Stream binary_file) {
      System.Text.Encoding encoding = System.Text.Encoding.UTF8;
      // Read string from binary file with UTF8 encoding
      byte[] buffer = new byte[30];
      binary_file.Read(buffer, 0, 30);
      return encoding.GetString(buffer);
    }
