    public static string DecodeSamlAuthnRequest(this string encodedAuthnRequest) {
      var utf8 = Encoding.UTF8;
      var bytes = Convert.FromBase64String(HttpUtility.UrlDecode(encodedAuthnRequest));
      using (var output = new MemoryStream()) {
        using (var input = new MemoryStream(bytes)) {
          using (var unzip = new DeflateStream(input, CompressionMode.Decompress)) {
            unzip.CopyTo(output, bytes.Length);
            unzip.Close();
          }
          return utf8.GetString(output.ToArray());
        }
      }
    }
