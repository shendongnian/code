    using System;
    
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Client;
    
    /// <summary>
    /// The plugin context.
    /// </summary>
    public class PluginContext
    {
        #region Constructors and Destructors
    
            /// <summary>
            /// Initializes a new instance of the <see cref="PluginContext"/> class.
            /// </summary>
            /// <param name="serviceProvider">
            /// The service provider.
            /// </param>
            /// <exception cref="ArgumentNullException">
            /// </exception>
            public PluginContext(IServiceProvider serviceProvider)
            {
                if (serviceProvider == null)
                {
                    throw new ArgumentNullException("serviceProvider");
                }
    
                // Obtain the execution context service from the service provider.
                this.PluginExecutionContext =
                    (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
    
                // Obtain the tracing service from the service provider.
                this.TracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
    
                // Obtain the Organization Service factory service from the service provider
                var factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
    
                // Use the factory to generate the Organization Service.
                this.OrganizationService = factory.CreateOrganizationService(this.PluginExecutionContext.UserId);
    
                this.OrganizationServiceContext = new OrganizationServiceContext(this.OrganizationService);
            }
    
            #endregion
    
        #region Properties
    
            /// <summary>
            /// Gets the organization service.
            /// </summary>
            /// <value>
            /// The organization service.
            /// </value>
            public IOrganizationService OrganizationService { get; private set; }
    
            /// <summary>
            /// Gets the plugin execution context.
            /// </summary>
            /// <value>
            /// The plugin execution context.
            /// </value>
            public IPluginExecutionContext PluginExecutionContext { get; private set; }
    
            /// <summary>
            /// Gets the service provider.
            /// </summary>
            /// <value>
            /// The service provider.
            /// </value>
            public IServiceProvider ServiceProvider { get; private set; }
    
            /// <summary>
            /// Gets the tracing service.
            /// </summary>
            /// <value>
            /// The tracing service.
            /// </value>
            public ITracingService TracingService { get; private set; }
    
            /// <summary>
            /// Gets the organization service context.
            /// </summary>
            /// <value>
            /// The organization service context.
            /// </value>
            public OrganizationServiceContext OrganizationServiceContext { get; private set; }
    
            #endregion
    
        #region Methods
    
            /// <summary>
            /// The trace.
            /// </summary>
            /// <param name="message">
            /// The message.
            /// </param>
            public void Trace(string message)
            {
                if (string.IsNullOrWhiteSpace(message) || this.TracingService == null)
                {
                    return;
                }
    
                if (this.PluginExecutionContext == null)
                {
                    this.TracingService.Trace(message);
                }
                else
                {
                    this.TracingService.Trace(
                        "{0}, Correlation Id: {1}, Initiating User: {2}", 
                        message, 
                        this.PluginExecutionContext.CorrelationId, 
                        this.PluginExecutionContext.InitiatingUserId);
                }
            }
    
            #endregion
    }
