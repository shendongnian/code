    public class character
    {
        public string Name, Owner;
        public int Str, Con, Dex, Int, Wis, Cha, AC, Speed, maxHP, currHP, AP, SV, Surges;
        public double Mod(int stat)
        {
             return Math.Floor(stat/2);
        }
    }
