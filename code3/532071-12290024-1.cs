    public bool IsValid(User user, Campaign campaign)
     {
       bool valid;
       foreach (IValidateable iv in strategies)
       {
          if (!iv.IsValid(user, campaign))
              valid = false;
       }
       // This returns true if all are valid, false if not (not sure if this is the logic you expect)
       return valid;
     }
