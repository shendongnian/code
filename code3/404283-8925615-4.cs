    public bool TryGetItem(int index, out int value)
    {
      lock(locker)
      {
        if(l.Count > index)
        {
          value = l[index];
          return true;
        }
        value = 0;
        return false;
      }
    }
