    private static void TestLateRegistration_SameBuilder_Ok()
    {            
        var rb = new RegistrationBuilder();            
        var assemblyCatalog = new AssemblyCatalog(typeof(LogService).Assembly, rb);
        using (var container = new CompositionContainer(assemblyCatalog))
        {                
            rb.ForType<LogService>().Export();
            var server = new TypeImportingLogService();
            //Use the same RegistrationBuilder.
            container.SatisfyImportsOnce(server, rb);
        }
    }
