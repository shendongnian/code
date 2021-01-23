    public void MyCallbackDelegate( string str );
    public void DoRequest(string request, MyCallbackDelegate callback)
    {
         // do stuff....
         callback("asdf");
    }
