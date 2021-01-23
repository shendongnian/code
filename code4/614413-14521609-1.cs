    public void Execute(IServiceProvider serviceProvider)
        {
            {
                // Obtain the execution context from the service provider.
                Microsoft.Xrm.Sdk.IPluginExecutionContext context = (Microsoft.Xrm.Sdk.IPluginExecutionContext)
                    serviceProvider.GetService(typeof(Microsoft.Xrm.Sdk.IPluginExecutionContext));
                //Extract the tracing service for use in debugging sandboxed plug-ins.
                ITracingService tracingService =
                    (ITracingService)serviceProvider.GetService(typeof(ITracingService));
                IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
                   
                if (context.InputParameters.Contains("Target") &&
                        context.InputParameters["Target"] is Entity)
                {
                Entity entity = (Entity)context.InputParameters["Target"];
                    Guid a = ((EntityReference)entity["bc_learninglicense"]).Id;
                    Entity llc = new Entity("bc_learninglicences");
                    llc.Id = a;
                            //fetchxml to get the sum total of estimatedvalue
                string value_sum = string.Format(@"         
                    <fetch distinct='false' mapping='logical' aggregate='true'> 
                        <entity name='bc_llbalance'>
                            <attribute name='bc_units' alias='units_sum' aggregate='sum' />
                               <filter type='and'>
                                <condition attribute='bc_learninglicense' operator='eq' value='{0}' uiname='' uitype='' />
                               </filter>
                        </entity>
                    </fetch>", a);
              
                           EntityCollection value_sum_result = service.RetrieveMultiple(new FetchExpression(value_sum));
                           decimal TotalValue = 0;
                           foreach (var c in value_sum_result.Entities)
                           {
                                TotalValue += ((Decimal)((AliasedValue)c["units_sum"]).Value);
                           }       
                            llc.Attributes["bc_unitsused"] = TotalValue;
                            service.Update(llc);
                }
            }
         }  
