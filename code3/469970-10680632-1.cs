    public class CombatMgr
    {
        // Delegate and Event
        public delegate void Combat();
        public event Combat OnEnterCombat;
        // Your main function
        public void EnterCombat()
        {
            // Calling event, and all subscribers to it
            if (OnEnterCombat != null)
            {
                OnEnterCombat();
            }
        }
    }
    // Side Class 1
    public class RogueCombat : CombatMgr
    {
        public void EnterCombat()
        {
            Console.WriteLine("Rogue Combats");
        }
    }
