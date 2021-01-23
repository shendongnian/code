    public string myConnectionString {
        get {
            return ((new Cypher().Decrypt(this["myConnectionString"].ToString())));
        }
    }
