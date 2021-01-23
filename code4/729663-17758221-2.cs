    using System.Web.Helpers;
    public void SavePassword(string unhashedPassword)
    {
        string hashedPassword = Crypto.HashPassword(unhashedPassword);
        //Save hashedPassword somewhere that you can retrieve it again.
        //Don't save unhashedPassword! Just let it go.
    }
    public bool CheckPassword(string unhashedPassword)
    {
        string savedHashedPassword = //get hashedPassword from where you saved it
    
        return Crypto.VerifyHashedPassword(savedHashedPassword, unhashedPassword)
    }
