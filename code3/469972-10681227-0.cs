    public class RogueCombat : CombatMgr
    {
        public RogueCombat(CombatMgr aMgr)
        {
            aMgr.OnEnterCombat += new Combat(EnterCombat);
        }
        public void EnterCombat()
        {
            Console.WriteLine("Rogue Combats");
        }
    }
