    public int ID { get; set; }
    public string Name { get; set; }
    private string email;
    public string Email {
        get { return email; }
        set { email = value; UpdateChecksum(); }
    }
    public string Username { get; set; }
    public string Password { get; set; }
    private string checksum;
    public string Checksum {
        get { return checksum; }
    }
    private void UpdateChecksum() {
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] originalBytes = ASCIIEncoding.Default.GetBytes(email);
        byte[] encodedBytes = md5.ComputeHash(originalBytes);
        checksum = BitConverter.ToString(encodedBytes);
    }
