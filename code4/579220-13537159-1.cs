    public class Weapons
    {
        public string AK_47_M;
        public string AK_47_S;
        public string AKS_74_Kobra;
        public string bizon_silenced;
        public string M1014;
        public string M16A2;
    }
    
    Weapons weapons = (new JavascriptSerializer())
        .Deserialize<Weapons>( "{" + 
             String.Join(",", File.ReadAllLines("weapons.txt")
                                  .Select(x => x.Replace(",",":"))
                                  .ToArray()) + 
        "}" );
    
    String AK = weaponsObj.AK_47_M;
