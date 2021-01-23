    //Main class
    public class CombatMgr
    {
        public virtual void EnterCombat()
        {
             //This gets called as CombatMgr.EnterCombat();
        }
    }
    //Side class
    public class RogueCombat : CombatMgr
    {
        public override void EnterCombat()
        {
             //I want this function to be 
             //linked to the EnterCombat function from CombatMgr.
             //And called when the main function is called.
        }
    }
