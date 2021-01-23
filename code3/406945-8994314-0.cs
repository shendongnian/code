     interface I1
        {
            int Id { get; set; }
        }
    
        public interface I2
        {
            string Name { get; set; }
        }
    
        public class Blah : I1, I2
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    
        static class ExtendIt
        {
            public static void ToEntity(this I1 x)
            {
                x.Id = 1;
            }
    
            public static void ToEntity(this I2 x)
            {
                x.Name = "hello";
            }
    
            public static void ToEntity(this Blah x)
            {
                (x as I1).ToEntity();
                (x as I2).ToEntity();
            }
    
    
        }
