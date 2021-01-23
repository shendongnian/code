    class Program
    {
        static void Main(string[] args)
        {
            character c = new character();
            c.Name = "Goofy";
            c.Owner = "Me";
            c.Str = 15;
            Console.WriteLine(c.Str.Mod());
            Console.Read();
        }
    }
    public class character
    {
        public string Name, Owner;
        public int Str, Con, Dex, Int, Wis, Cha, AC, Speed, maxHP, currHP, AP, SV, Surges;
    }
    public static class Ext
    {
        public static int Mod(this int value)
        {
            return (int)Math.Floor(value / 2.0);
        }
    }
