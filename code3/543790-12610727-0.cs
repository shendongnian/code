    private int isArmUpCounter = 5;
    private bool isArmUp = false;
    private void OnSkeletonReady() {
      if (myArm.Angle > 70 && myArm.Angle < 80)
      {
        if (isArmUp == false)
        {
          isArmUp = true;
          isArmUpCounter = 5;
          armUpTimer.Start();
        }
      }
      else
      {
        if (isArmUp == true && isArmUpCounter > 0)
        {
          Console.WriteLine("You dropped your arm too soon!");
        }
        isArmUp = false;
        armUpTimer.Stop();
      }
    }
    private void OnArmUpTimerTick() {
        // one a 1 second tick
        isArmUpCounter--;
    }
