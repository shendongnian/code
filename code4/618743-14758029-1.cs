    //client.
    ...
    try {
        Internal.Say("Hello");
    }
    catch (WrongMessageException wme) {
        //deal with wrong message situation.
    }
    catch (SessionTimeOutException stoe) {
        //deal with session timeout situation.
    }
