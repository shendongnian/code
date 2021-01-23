        public static string ComputeSha1(string data)
        {
            var sha1Digest = new Org.BouncyCastle.Crypto.Digests.Sha1Digest();
            var hash = new byte[sha1Digest.GetDigestSize()];
            var dataBytes = Encoding.UTF8.GetBytes(data);
            foreach (var b in dataBytes)
            {
                sha1Digest.Update(b);
            }
            sha1Digest.DoFinal(hash, 0);
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
        }
