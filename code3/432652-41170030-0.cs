    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
        [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
        public class ServiceODataAFR : EntityFrameworkDataService<PortalContext>
        {
            public static void InitializeService(DataServiceConfiguration config)
            {
                ValidarAcesso();
    
                config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
                config.SetEntitySetAccessRule("*", EntitySetRights.AllRead);
            }
    
            protected override void OnStartProcessingRequest(ProcessRequestArgs args)
            {
                ValidarAcesso();
    
                base.OnStartProcessingRequest(args);
            }
    
            private static void ValidarAcesso()
            {
                using (var context = new PortalWeb())
                {
                    if (!context.UsuarioEstaNoGrupo(EnumGrupoPermissao.AdministradorAFR.GetTitle()))
                    {
                        throw new AddressAccessDeniedException();
                    }
                }
            }
