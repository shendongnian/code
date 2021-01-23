      string salt = "kuc5bixg5u88s4k8ggss4osoksko0g8";
      string input = "lolwut";
      string passAndSalt = String.Format("{0}{{{1}}}", input, salt);
      System.String Hashed = System.BitConverter.ToString(((System.Security.Cryptography.SHA512)new System.Security.Cryptography.SHA512Managed()).ComputeHash(System.Text.Encoding.ASCII.GetBytes(passAndSalt))).Replace("-", "");
      // Hashed.ToLower()
