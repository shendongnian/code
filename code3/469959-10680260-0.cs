    //Main class
    public class CombatMgr
    {
        virtual public void EnterCombat()
        {
             //This gets called as CombatMgr.EnterCombat();
        }
    }
    //Side class
    public class RogueCombat : CombatMgr
    {
        override public void EnterCombat()
        {
             //I want this function to be 
             //linked to the EnterCombat function from CombatMgr.
             //And called when the main function is called.
        }
    }
