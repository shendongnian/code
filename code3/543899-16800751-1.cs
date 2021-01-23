    try
    {
        TestOcx myCom = new TestOcx();
        result = myCom.PassString(ref input); // <== MAJOR ERROR!
        // do stuff with result...
        return true;
    }
    catch (Exception ex)
    {
        log.Add("Exception: " + ex.Message); // THIS NEVER GETS CALLED
        return false;
    }
    catch
    {
       //do something here
    }
