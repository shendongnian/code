    private class Steps
    {
       private int _stepIndex = 0;
       public void Process()
       {
           switch(_stepIndex)
           {
              case 0: // First Step
                 ...  // Perform business logic for step 1.
                 break;
              case 1: // Second Step
                 ...  // Perform business logic for step 2.
                 break;
           }
           _stepIndex++;
       }
    }
