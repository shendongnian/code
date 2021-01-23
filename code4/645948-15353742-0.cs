     public class MyClassDTO
    {
        public string P1 { get; set; }
        public string P2 { get; set; }
    }
    public static class MyClassDtoExtension
    {
        public static string ToCalculatedProperty(this MyClassDTO obj)
        {
            return obj.P1 + obj.P2;
        }
    }
