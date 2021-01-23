    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Runtime.Serialization.Formatters.Binary;
    
    namespace Uniq
    {
    	[Serializable]
    	class Address
    	{
    	    public string AddressLine1 { get; set; }
    	    public string AddressLine2 { get; set; }
    	    public string City { get; set; }
    	    public string Zip { get; set; }
    	    public string Country { get; set; }
    	} 
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			Address address1 = new Address(){AddressLine1 = "a1"};
    			Address address2 = new Address(){AddressLine1 = "a1"};
    			Address address3 = new Address(){AddressLine1 = "a2"};
    			string unique1 = GetUniqueIdentifier(address1);
    			string unique2 = GetUniqueIdentifier(address2);
    			string unique3 = GetUniqueIdentifier(address3);
    			Console.WriteLine(unique1);
    			Console.WriteLine(unique2);
    			Console.WriteLine(unique3);
    		}
    		public static string GetUniqueIdentifier(object obj){
    			if (obj == null) return "0";
    			SHA256 mySHA256 = SHA256Managed.Create ();
    			BinaryFormatter formatter = new BinaryFormatter ();
    			MemoryStream stream = new MemoryStream();
    			formatter.Serialize(stream, obj);
    			byte[] hash = mySHA256.ComputeHash(stream.GetArray());
    			string uniqId = Convert.ToBase64String(hash);
    			return uniqId;
    		}
    	}
    }
