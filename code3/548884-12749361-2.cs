    public bool TryRead(InTouchDdeWrapper wrapper, string prop, out string value) 
    {
      try 
      {
        value = wrapper.Read(prop);
        return true;
      }
      catch (Exception e)
      {
        value = null;
        return false;
      }  
    }
