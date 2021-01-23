    using System;
    using System.Numerics;
    using System.Security.Cryptography;
    using System.Text;
    
    class App
    {
        static void Main()
        {
          var parameters = new RSAParameters();
          parameters.Exponent=B("3"); 
          parameters.Modulus=B("8029845567507477803775928519657066509146751167600087041355508603090505634905205233922950527978886894355290423984597739819216469551137046641801207199138209"); 
          parameters.D=B("5353230378338318535850619013104711006097834111733391360903672402060337089936682996269976597251251223844095913209399106464214877696419418951728015128013411");
          parameters.P=B("102067954277225510613941189336789903269738979633396754230261162567549753196947");
          parameters.Q=B("78671563708406591396117399809764267229341143260756252277657051641634753921147");
          parameters.DP=B("68045302851483673742627459557859935513159319755597836153507441711699835464631");
          parameters.DQ=B("52447709138937727597411599873176178152894095507170834851771367761089835947431");
          parameters.InverseQ=B("26458340158787140383846156526777567128582042036682248240414722856369310516021");
    
          var rsa = new RSACryptoServiceProvider();
          rsa.ImportParameters(parameters);
          var ciphertext = rsa.Encrypt(Encoding.ASCII.GetBytes("Hello"), false);
          Console.WriteLine(Encoding.ASCII.GetString(rsa.Decrypt(ciphertext, false)));
        }
    
        static byte[] B(string s)
        {
          var b = BigInteger.Parse(s);
          var ret = b.ToByteArray();
          if (ret[ret.Length - 1] == 0) 
          {
            Array.Resize(ref ret, ret.Length - 1);
          }
          Array.Reverse(ret);
          return ret;
        }
    }
