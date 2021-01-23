    Send(IEnumerable<User> users)
    {...}
    void Send(params User[] recipients)
    {
        Send((IEnumerable<User>)recipients); // To IEnumerable overload
    }
