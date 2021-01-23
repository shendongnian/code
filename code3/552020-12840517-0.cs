    class CombatEventList
    {
       public static AddEvent(CombatEvent event, int ticksTillHappens)   
    }
    
    virtual class CombatEvent
    {
        public virtual void CombatAction()
    }
    
    class PlayerActionChoice : ComabtEvent
    {
       public void CombatAction
       {
           var playerAction = GetUserDecision();//returns i.e CombatEvent PlayerMeeleAttack
           CombatEventList.AddEvent(playerAction, 0);
       }
    }
    
    class PlayerMeeleAttack : CombatEvent
    {
       int cooldownInTicks = 50;
    
       public void CombatAction
       {
           MakeAttack()//damages the moster etc - all the stuff the attack is supposed to do
           var nextEvent = new PlayerActionChoice();
           CombatEventList.AddEvent(nextEvent, cooldownInTicks);
       }
    }
