    public class CubeDescriptor
    {
        public EcubeType CubeType;
        public Texture2D Texture;
        public bool isMineable;
    }
    
    public static CubeDescriptor[] TypeTable = new {
                                                   new CubeDescriptor(EcubeType.Air, null, false),
                                                   new CubeDescriptor(EcubeType.Grass, grass, false),
                                                   new CubeDescriptor(EcubeType.Stone, stone, true)
                                               };
