           public static MyCustomClass Parse(object o)
        {
            if (o == null)
                return null;
            try
            {
                if (o is MyCustomClass)
                    return (MyCustomClass)o;
            }
            catch
            {
                return null;
            }
            return null;
            
        }
