    [AppSettingsConfiguration]
    public class ClientConfiguration : Configuration<IClientConfiguration>
    {
        [RegistryConfiguration]
        public bool BypassCertificateVerification { get; set; }
    }
