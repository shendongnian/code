    public interface IEmailAddressesProvider
    {
        string ProviderName { get; }
        IEnumerable<EmailAddress> EmailUsers { get; set;};
    }
