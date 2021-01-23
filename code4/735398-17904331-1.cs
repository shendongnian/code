    // Iterate the list backwards so we never skip items or accidentally
    // access past the end of the list.
    for (int i = coins.Count - 1; i >= 0; --i)
    {
       if (coins[i].delete)
       {
          coins.RemoveAt(i);
       }
       else
       {
          coins[i].somethingElse();
       }
    }
