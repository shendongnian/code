    for (nb = 0; nb < oldhashsize; nb++)
    {
        bucket oldb = buckets[nb];
        if ((oldb.key != null) && (oldb.key != buckets))
        {
            putEntry(newBuckets, oldb.key, oldb.val, oldb.hash_coll & 0x7FFFFFFF);
        }
    }
    private void putEntry (bucket[] newBuckets, Object key, Object nvalue, int hashcode)
    {
        BCLDebug.Assert(hashcode >= 0, "hashcode >= 0");  // make sure collision bit (sign bit) wasn't set.
        uint seed = (uint) hashcode;
        uint incr = (uint)(1 + (((seed >> 5) + 1) % ((uint)newBuckets.Length - 1)));
        
        do 
        {
            int bucketNumber = (int) (seed % (uint)newBuckets.Length);
            if ((newBuckets[bucketNumber].key == null) || (newBuckets[bucketNumber].key == buckets)) 
            {
                newBuckets[bucketNumber].val = nvalue;
                newBuckets[bucketNumber].key = key;
                newBuckets[bucketNumber].hash_coll |= hashcode;
                return;
            }
            newBuckets[bucketNumber].hash_coll |= unchecked((int)0x80000000);
            seed += incr;
            } while (true);
        }
    }
