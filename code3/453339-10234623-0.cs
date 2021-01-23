    [ContentProcessor(DisplayName = "MyTextureProcessor")]
    public class TextureContentProcessor : TextureProcessor
    {
        public override TextureContent Process(TextureContent input, ContentProcessorContext context)
       {          
            TextureContent data = base.Process(input, context);
            
            // Convert data
            return data;
       }
    }
