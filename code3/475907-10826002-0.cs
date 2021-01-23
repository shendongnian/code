    ActionResult SaveA(long id, AViewModel)
    {
          //.... Action to be conducted in case it is form A.
    }
    ActionResult SaveB(...., BViewModel)
    {
           //... Action to be conducted in case it is form B.
    }
    
    // Your view models can be structured for code reuse as well.
    class AViewModel {  ...  }
    class BViewModel : AViewModel {  ...  }
