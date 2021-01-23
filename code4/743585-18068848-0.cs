    public abstract class Chunk {
       public string Text { get; private set; }
    
       protected Chunk(string text) {
          Text = text;
       }
    }
    
    public class ATypeChunk : Chunk {
       public ATypeChunk(string text) : base(text) { }
    }
    
    public class BTypeChunk : Chunk {
       public BTypeChunk(string text) : base(text) { }
    }
