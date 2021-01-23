    static public class StringHash
        {
            //---------------------------------------------------------------------
            static public Int64 RSHash(String str)
            {
                const Int32 b = 378551;
                Int32 a = 63689;
                Int64 hash = 0;
    
                for (Int32 i = 0; i < str.Length; i++)
                {
                    hash = hash * a + str[i];
                    a = a * b;
                }
    
                return hash;
            }
            //---------------------------------------------------------------------
            static public Int64 JSHash(String str)
            {
                Int64 hash = 1315423911;
    
                for (Int32 i = 0; i < str.Length; i++)
                {
                    hash ^= ((hash << 5) + str[i] + (hash >> 2));
                }
    
                return hash;
            }
            //---------------------------------------------------------------------
            static public Int64 ELFHash(String str)
            {
                Int64 hash = 0;
                Int64 x = 0;
    
                for (Int32 i = 0; i < str.Length; i++)
                {
                    hash = (hash << 4) + str[i];
    
                    if ((x = hash & 0xF0000000L) != 0)
                    {
                        hash ^= (x >> 24);
                    }
                    hash &= ~x;
                }
    
                return hash;
            }
            //---------------------------------------------------------------------
            static public Int64 BKDRHash(String str)
            {
                const Int64 seed = 131; // 31 131 1313 13131 131313 etc..
                Int64 hash = 0;
    
                for (Int32 i = 0; i < str.Length; i++)
                {
                    hash = (hash * seed) + str[i];
                }
    
                return hash;
            }
            //---------------------------------------------------------------------
            static public Int64 SDBMHash(String str)
            {
                Int64 hash = 0;
    
                for (Int32 i = 0; i < str.Length; i++)
                {
                    hash = str[i] + (hash << 6) + (hash << 16) - hash;
                }
    
                return hash;
            }
            //---------------------------------------------------------------------
            static public Int64 DJBHash(String str)
            {
                Int64 hash = 5381;
    
                for (Int32 i = 0; i < str.Length; i++)
                {
                    hash = ((hash << 5) + hash) + str[i];
                }
    
                return hash;
            }
            //---------------------------------------------------------------------
            static public Int64 DEKHash(String str)
            {
                Int64 hash = str.Length;
    
                for (Int32 i = 0; i < str.Length; i++)
                {
                    hash = ((hash << 5) ^ (hash >> 27)) ^ str[i];
                }
    
                return hash;
            }
            //---------------------------------------------------------------------
            static public Int64 BPHash(String str)
            {
                Int64 hash = 0;
    
                for (Int32 i = 0; i < str.Length; i++)
                {
                    hash = hash << 7 ^ str[i];
                }
    
                return hash;
            }
            //---------------------------------------------------------------------
            static public Int64 FNVHash(String str)
            {
                Int64 fnv_prime = 0x811C9DC5;
                Int64 hash = 0;
    
                for (Int32 i = 0; i < str.Length; i++)
                {
                    hash *= fnv_prime;
                    hash ^= str[i];
                }
    
                return hash;
            }
            //---------------------------------------------------------------------
            static public Int64 APHash(String str)
            {
                Int64 hash = 0xAAAAAAAA;
    
                for (Int32 i = 0; i < str.Length; i++)
                {
                    if ((i & 1) == 0)
                    {
                        hash ^= ((hash << 7) ^ str[i] * (hash >> 3));
                    }
                    else
                    {
                        hash ^= (~((hash << 11) + str[i] ^ (hash >> 5)));
                    }
                }
    
                return hash;
            }
        }
