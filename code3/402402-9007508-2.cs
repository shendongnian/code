    public class Product
    {
       [DataMember]
       public int productID;
       [DataMember]
       public string productName;        
       [DataMember]
       public List<Part> Parts = new List<Part>(); // you might have some trouble here.
                               //not sure if any other attributes are needed for Parts,
                               //since you said this is an entity; also not sure if you 
                               //can even have a list of entities or it needs to be an
                               //entity collection or what it needs to be.  You might
                               //have to make two separate calls - one to get the products
                               //and then one to get the parts.
    }
