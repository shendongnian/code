    RsaKeyParameters privParameters = new RsaPrivateCrtKeyParameters(mod, pubExp, privExp, p, q, pExp, qExp, crtCoef);
    RsaKeyParameters pubParameters = new RsaKeyParameters(false, mod, pubExp);
    IAsymmetricBlockCipher eng = new Pkcs1Encoding(new RsaEngine());
    eng.Init(false, privParameters);
    byte[] encdata = System.Convert.FromBase64String("{the enc string}");
    encdata = eng.ProcessBlock(encdata, 0, encdata.Length);
    string result = Encoding.UTF8.GetString(encdata);
