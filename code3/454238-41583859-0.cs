        [Test]
        public void CreateHash_VersusComputeHash_ReturnsEquivalent()
        {
            // USING TRADITIONAL .NET:
            var key = new byte[32];
            var contentBytes = Encoding.UTF8.GetBytes("some kind of content to hash");
            new RNGCryptoServiceProvider().GetBytes(key);
            var alg = new HMACSHA1(key); // Bouncy castle usage does not differ from this
            var result = alg.ComputeHash(contentBytes);
            // USING PCL CRYPTO:
            var algorithm = WinRTCrypto.MacAlgorithmProvider.OpenAlgorithm(MacAlgorithm.HmacSha1);
            byte[] mac;
            using (var hasher = algorithm.CreateHash(key))
            {
                hasher.Append(contentBytes);
                mac = hasher.GetValueAndReset();
            }
            // Assert results:
            Assert.AreEqual(result.Length, mac.Length);
            for (var i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(result[i], mac[i]);
            }
        }
