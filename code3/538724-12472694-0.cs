    FileStream fs = new FileStream(CERT_PATH, FileMode.Open);
    Pkcs12Store ks = new Pkcs12Store(fs, CERT_PASSW.ToCharArray());
    string alias = null;
    foreach (string al in ks.Aliases) {
        if (ks.IsKeyEntry(al) && ks.GetKey(al).Key.IsPrivate) {
            alias = al;
            break;
        }
    }
