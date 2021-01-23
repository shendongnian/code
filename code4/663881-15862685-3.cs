    public static string GetUniqueIdentifier(object obj){
    	if (obj == null) return "0";
    	SHA256 mySHA256 = SHA256Managed.Create ();
    	StringBuilder stringRep = new StringBuilder();
    	obj.GetType().GetProperties()
    				.ToList().ForEach(p=>stringRep.Append(
    			p.GetValue(obj, null) ?? '¨'
    			).Append('^'));
    	Console.WriteLine(stringRep);
    	Console.WriteLine(stringRep.Length);
    	byte[] hash = mySHA256.ComputeHash(Encoding.Unicode.GetBytes(stringRep.ToString()));
    	string uniqId = Convert.ToBase64String(hash);
    	return uniqId;
    }
