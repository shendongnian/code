    // Main Class
    public class CombatMgr
    {
        // Delegate that all child members need to assign, so parent
        // can call
        public Action _childMustAssign;
        // Your main function
        public void EnterCombat()
        {
            // Calling child method
            if (_childMustAssign != null)
            {
                _childMustAssign.Invoke();
            }
        }
    }
    // Side Class
    public class RogueCombat : CombatMgr
    {
        // Constructor, a place to assign the delegate
        public RogueCombat()
        {
            this._childMustAssign = EnterCombat;
        }
        
        // This will be called by CombatMgr.EnterCombat();
        public void EnterCombat()
        {
            // TODO: 
        }
    }
