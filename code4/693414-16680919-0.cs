public class TwoEventGroup
{
   private bool _eventAFired;
   private bool _eventBFired;
   public void EventAHandler()
   {
      _eventAFired = true;
      TestAndFire();
   }
   public void EventBHandler()
   {
      _eventBFired = true;
      TestAndFire();
   }
   private void TestAndFire()
   {
      if (_eventAFired && _eventBFired)
      {
         _eventAFired = false;
         _eventBFired = false;
         if (GroupEvent != null)
           GroupEvent();
      }
   }
   public event Action GroupEvent;
}
