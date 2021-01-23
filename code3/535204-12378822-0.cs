      public void IWantYouToAttackSuperSlow(IGameObject target)
    {
       //Let's get the action component for the gameobject 
       IActionComponent actionComponent = ActionComponentsFactory.GetTimedActionComponentIfAvailable(int.MaxValue); 
    }
