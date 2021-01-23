        try
        {
            string s = null;
            ProcessString(s);
        }
        // Most specific:
        catch (InvalidCastException e) { out_one(e); }
        catch (ArgumentNullException e) { out_two(e); }
        // Least specific - anything will get caught
        // here as all exceptions derive from this superclass
        catch (Exception e)
        {
            // performance-wise, this would be better off positioned as
            // a catch block of its own, calling a function (not forking an if)
            if((e is SystemException) { out_two(); }
            else { System..... }
        }
