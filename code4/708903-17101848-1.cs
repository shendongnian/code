    string plaintext = userName + "|" + DateTime.Today.AddDays(2).ToString() + "|" + userEmailAddress;
    WebBase64 ciphertext;
    string key = (new Random().Random(10000000) + 1000).ToString();
    //pretend this dictionary represents a database storage medium
    public static Dictionary<string,string> CypherTextToKey= new Dictionary<string,string>();
    //encrypting
    using (var encrypter = new Encrypter(key))  
    {
       ciphertext = encrypter.Encrypt(plaintext);
    }
    CypherTextToKey.Add(cyphertext, key);
    SendEmail(user, "Encrypted/"+cyphertext");
