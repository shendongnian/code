<Pre>
Try by use SHA1CryptoServiceProvider.ComputeHash method? 
It takes a byte array and returns a SHA1 hash which is identical 
for byte arrays. Performance is good.
string byte1hash;
string byte2hash;          
using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
{
     byte1hash= Convert.ToBase64String(sha1.ComputeHash(byteArray1));
     byte2hash= Convert.ToBase64String(sha1.ComputeHash(byteArray2));                
}
if (string.Equals(byte1hash, byte2hash))
{
    //States the byte arrays are same..
}
If you are not worried about security, then you go for MD5
</Pre>
