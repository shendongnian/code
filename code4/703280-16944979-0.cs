    // ...
    catch (IBM.Data.Informix.IfxException ex)
    {
        LogError(ex, query);  // NOTE
        SendErrorEmail(ex, query.CommandText);
        DisplayError();
    }
