        try
        {
           // inset data
        }
        catch (SqlException ex)
        {
            if (ex.Message.ToLower().Contains("duplicate key"))
            {
                if (ex.Message.ToLower().Contains("url"))
                {
                    return 1; // Sure, that's one good way to do it
                }
                if (ex.Message.ToLower().Contains("email"))
                {
                    return 2; // Sure, that's one good way to do it
                }
            }
            return 3; // EVIL! Or at least quasi-evil :)
        }
