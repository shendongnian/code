    public void RunTheseActions(params Action[] TheActions)
    {
      foreach(Action theAction in TheActions)
      {
        theAction();
      }
    }
    //called by
    RunTheseActions(ThisAction, ThatAction, TheOtherAction);
