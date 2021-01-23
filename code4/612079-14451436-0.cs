    public interface IAuthProvider
    {
        string GenerateKey();
    }
    public static class IAuthProviderExtensions
    {
        public static string GenerateSecret(this IAuthProvider provider)
        {
             return provider.GenerateKey();
        }
    }
