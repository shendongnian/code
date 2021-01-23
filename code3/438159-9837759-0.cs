    var sha1 = System.Security.Cryptography.SHA1.Create();
    byte[] buf = System.Text.Encoding.UTF8.GetBytes("test");
    byte[] hash= sha1.ComputeHash(buf, 0, buf.Length);
    //var hashstr  = Convert.ToBase64String(hash);
    var hashstr = System.BitConverter.ToString(hash).Replace("-", "");
