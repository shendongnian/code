    //parse out hex digits in calling code
    static long NextHash(HashSet<long> hashes, int count)
    {
        System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
        long l = MD564(md5.ComputeHash(IntToArray(count)));
        if(!hashes.Contains(l)){
            hashes.Add(l);
            return l;
        } else return -1; //check this in calling code for failure
    }
    static long MD564(byte[] bytes)
    {
        long result = 0;
        for (int i = 15; i > -1; i--) {
            result <<= 1;
            result += bytes[i];
        }
        return result;
    }
    static byte[] IntToArray(int i)
    {
        byte[] bytes = new byte[4];
        for(int j=0;j<4;j++){
        bytes[j] = (byte)i;
        i>>=8;    
        }
    }
