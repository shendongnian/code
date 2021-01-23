    public byte[] CreateFiller(int length, Random rnd) {
      string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
      return Encoding.UTF8.GetBytes(Enumerable.Range(0, length).Select(i => chars[rnd.Next(chars.Length)]).ToArray());
    }
    
    // only use the overload that creates a Random object itself if you use it once, not in a loop
    public byte[] CreateFiller(int length) {
      return CreateFiller(length, new Random());
    }
