    public class Plugin : IPlugin
    {
      // Here we declare our tracer.
      private ITracingService _trace;
    
      public void Execute(IServiceProvider serviceProvider)
      {
        // Here we create it.
        _trace = (ITracingService)serviceProvider
          .GetService(typeof(ITracingService));
        _trace.Trace("Commencing.");
    
        // Here we crash our plugin just to make sure that we can see the logs 
        // with trace information. This statement should be gradually moved down
        // the code to discover where exactly the plugin brakes.
        throw new Exception("Intentional!");
    
        IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider
          .GetService(typeof(IPluginExecutionContext));
        Entity entity;
        ...
    
        try { ... }
        catch (FaultException<OrganizationServiceFault> ex)
        {
          throw new InvalidPluginExecutionException(
            "An error occurred in the plug-in.", ex);
        }
    
        // Here we catch all other kinds of bad things that can happen.
        catch(Exception exception) { throw exception; }
      }
    
      private static void TaxCreator(IOrganizationService service, Guid QPID)
      {
        // Here we add a line to the trace hoping that the execution gets here.
        _trace.Trace("Entered TaxCreator.");
    
        using (var crm = new XrmServiceContext(service))
        {
          var QuoteProduct = crm.QuoteDetailSet.Where(...).First();
          var SaleSetting = crm.new_salessettingSet.Where(...).First();
          double TaxPercent = (Convert.ToDouble(...) / 100);
    
          // Here we add a line to the trace to see if we get past this point.
          _trace.Trace("Approaching if statement.");
    
          if (QuoteProduct.IsPriceOverridden == false) { ... }
        }
      }
    
      private static void TaxUpdater(IOrganizationService service, Guid QPID)
      {
        // Here we add a line to the trace hoping that the execution gets here.
        _trace.Trace("Entered TaxUpdater.");
      
        ...
      }
    }
