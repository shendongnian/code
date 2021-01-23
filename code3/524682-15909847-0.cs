    public static string EncodeSamlAuthnRequest(this string authnRequest) {
        var bytes = Encoding.UTF8.GetBytes(authnRequest);
        using (var output = new MemoryStream()) {
          using (var zip = new DeflateStream(output, CompressionMode.Compress)) {
            zip.Write(bytes, 0, bytes.Length);
          }
          var base64 = Convert.ToBase64String(output.ToArray());
          return HttpUtility.UrlEncode(base64);
        }
      }
