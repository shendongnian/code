    public class Character // C should be uppercase here.
    {
       public string Name, Owner;
       public int Str, Con, Dex, Int, Wis, Cha, AC, Speed, maxHP, currHP, AP, SV, Surges;
       public double ModMe()
       {
          return Math.Floor(this.Str / 2); // Math.Floor returns double
       }
    }
    character c = new character();
    c.Name = "Goofy";
    c.Owner = "Me";
    c.Str = 15;
    MessageBox.Show(c.ModMe());
