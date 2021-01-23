    public static X509Certificate2 GetCertificate(string _certSn)
            {
                //selezione del token di firma
    
                var st = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                st.Open(OpenFlags.ReadOnly);
                var col = st.Certificates;
                var card = col.Cast<X509Certificate2>().FirstOrDefault(t => t.SerialNumber == _certSn);
    
                st.Close();
    
                return card;
            }
    public static X509Certificate2 selectCert(StoreName store, StoreLocation location, string windowTitle, string windowMsg)
    {
    
        X509Certificate2 certSelected = null;
        X509Store x509Store = new X509Store(store, location);
        x509Store.Open(OpenFlags.ReadOnly);
    
        X509Certificate2Collection col = x509Store.Certificates;
        X509Certificate2Collection sel = X509Certificate2UI.SelectFromCollection(col, windowTitle, windowMsg, X509SelectionFlag.SingleSelection);
    
        if (sel.Count > 0)
        {
            X509Certificate2Enumerator en = sel.GetEnumerator();
            en.MoveNext();
            certSelected = en.Current;
        }
    
        x509Store.Close();
    
        return certSelected;
    }
