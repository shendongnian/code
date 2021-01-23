    byte[] imagesize = File.ReadAllBytes(@"C:\image.jpeg");
    string base64String = Convert.ToBase64String(imagesize);
    List<string> chunks = new List<string>();
    for (int i = 0; i < base64String.Length; i+=512)
    {
        chunks.Add(base64String.Substring(i, Math.Min(512, base64String.Length - i)));
    }
