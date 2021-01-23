    public class weapons
    {
        public string AK_47_M;
        public string AK_47_S;
        public string AKS_74_Kobra;
        public string bizon_silenced;
        public string M1014;
        public string M16A2;
    }
    
    string[] weaponsArray = File.ReadAllLines("weapons.txt");
    weapons weaponsObj = (new JavascriptSerializer())
                        .Deserialize<weapons>( String.Format("{{ {0} }}", 
    					                    String.Join(",", weaponsArray.Select(x => x.Replace(",",":")).ToArray()
                                       )));
    
    String AK = weaponsObj.AK_47_M;
