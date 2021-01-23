    List<Smurf> smurfs = GetSomeSmurfs();
    for (in i = smurfs.Count - 1; i >= 0; i--)
    {
       Smurf smurfToRemove = smurfs[i];
       if(conditionToRemoveSmurf)
       {
          //Do whatever you need with that smurf before removing it. 
          //(Dispose(), give to azrael, whatever)
          smurfs.Remove(smurfToRemove);
       }
    }
