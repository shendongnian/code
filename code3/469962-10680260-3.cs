     //Main class
    public class CombatMgr
    {
        public void EnterCombat()
        {
            // write logic here you want to execute for every child instance.
            // then call the virtual protected method.
            this.OnEnterCombat();
        }
        protected virtual void OnEnterCombat() { }
    }
    //Side class
    public class RogueCombat : CombatMgr
    {
        protected override void OnEnterCombat()
        {
            // Write logic for child class here
        }
    }
