    void Open(IKnob knob)
    {
       knob.Turn();
       knob.Pull();
    }
    
    class TrappedDoor:IKnob,IMaterial,ISomethingElse,IHaveTheseOtherCapabilitiesAsWell
    {
      private bool TrapAlreadySprung{get;set;}
      //more complex properties would allow traps to be attached either to the knob, or the door, such that in one case turning the knob activates the trap, and in the other, Pull activates the trap
      public Turn() { 
        if(! TrapAlreadySprung)
        {
          MessageBox("You hit your head, now you're dead");
        }
      }
    }
