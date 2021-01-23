    // create a class for each type of object you're going to be dealing with
    public class ProductNameInformation { ... }
    public class Product { ... }
    
    // load a list from a SqlDataReader (much faster than loading a DataSet)
    List<Product> products = GetProductsUsingSqlDataReader(); // don't actually call it that :)
    
    // The only thing I can think of where DataSets are better is indexing certain columns.
    // So if you have indices, just emulate them with a hashtable:
    Dictionary<string, Product> index1 = products.ToDictionary( ... );
