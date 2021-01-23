    public string GetRandomGUID(int length)
    {
      // Get the GUID
      string guidResult = System.Guid.NewGuid().ToString();
      
      // Remove the hyphens
      guidResult = guidResult.Replace("-", string.Empty);
      
      // Make sure length is valid
      if (length <= 0 || length > guidResult.Length)
        throw new ArgumentException("Length must be between 1 and " + guidResult.Length);
      
      // Return the first length bytes
      return guidResult.Substring(0, length);
    }
