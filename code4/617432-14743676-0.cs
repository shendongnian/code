    RSAParameters rsaKeyInfo = new RSAParameters
                                               {
                                                   Exponent = new byte[] { 1, 0, 1 },
                                                   Modulus = p.Multiply(q).ToByteArray(),
                                                   P = p.ToByteArray(),
                                                   Q = q.ToByteArray(),
                                                   DP = d.Remainder(p.Subtract(BigInteger(1))).ToByteArray(),
                                                   DQ = d.Remainder(q.Subtract(BigInteger(1))).ToByteArray(),
                                                   InverseQ = q.ModInverse(p).ToByteArray(),
                                                   D = d.ToByteArray()
                                               };
