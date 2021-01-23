    public string Convert(string winPhone7Anid)
    {
        var anidAsBytes = System.Text.Encoding.Unicode.GetBytes("A=" + winPhone7Anid + "&E=f48&W=3");
        var macObject = new HMACSHA256(anidAsBytes.Take(anidAsBytes.Length / 2).ToArray());
        var hashedBytes = macObject.ComputeHash(new Guid("XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX").ToByteArray());
        return System.Convert.ToBase64String(hashedBytes);
    }
