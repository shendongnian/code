     public class VideoConverterFactroy
     {
       private static readonly IEnumerable<IVideoConverters> SupportedConverters = new IVideoConverter[] {new VideoConverter1(), new VideoConverter2(),....}
       public IVideoConverter GetConverter(string inputId, string outputId)
       {
          for(int i=0; i<SupportedConverters.length; i++)
          {
            if(SupportedConverters[i].IsSupported(inputId, outputId)
              return SupportedConverters[i];
          }
          
          return null;
       }
    }
