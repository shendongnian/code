    public interface IModel
    {
         int ComputeFavoriteNumber(); // or a property
    }
    ...
    // class is practically unknown to deserializing module
    internal class ErnieModel : IModel
    {
        public int ComputeFavoriteNumber()
        {
            return 8243721;
        }
    }
    ...
 
    // deserializing module
    var bf = new BinaryFormatter();
    using (var ms = new MemoryStream())
    {
        bf.Serialize(ms, new ErnieModel()); // In reality ErnieModel should be unknown to the deserializing code, this is just to fill the Stream with data
        var model = (IModel)bf.Deserialize(sr);
        Console.WriteLine("Favorite number: {0}", model.ComputeFavoriteNumber());
    }
