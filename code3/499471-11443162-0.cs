    SHA256Managed sha = new SHA256Managed();
    byte[] checksum = sha.ComputeHash(stream);
    var hash = BitConverter.ToString(checksum).Replace("-", String.Empty);
    // Store hash into a dictionary
    
