public bool IsAuthenticationValid(string userName, string password)
{
    using (var context = new PrincipalContext(ContextType.Machine))
    {
        return context.ValidateCredentials(userName, password);
    }
}
