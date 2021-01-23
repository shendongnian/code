        public void Execute(IServiceProvider serviceProvider)
        {
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            Entity entity;
            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {
                entity = (Entity)context.InputParameters["Target"];
                if (entity.LogicalName != "quotedetail") { return; }
            }
            else
            {
                return;
            }
            try
            {
                IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
                QuoteDetail QuoteProduct = ((Entity)context.InputParameters["Target"]).ToEntity<QuoteDetail>();
                if (context.MessageName == "Create" || context.MessageName == "Update")
                    // && context.Depth < 3) //try to avoid depth unless you have to have it
                {
                    TaxSetter(service, QuoteProduct);
                }
            }
            catch (FaultException<OrganizationServiceFault> ex)
            {
                throw new InvalidPluginExecutionException( "An error occurred in the plug-in.", ex);
            }
        }
        private static void TaxSetter(IOrganizationService service, QuoteDetail product)
        {
            using (var crm = new TrainingContext(service))
            {
                var QuoteProduct = product.ToEntity<QuoteDetail>();
                if (QuoteProduct.IsPriceOverridden == false)
                {
                    double TaxPercent = Convert.ToDouble(50 / 100);
                    decimal Tax = (decimal)Convert.ToDecimal(Convert.ToDouble(QuoteProduct.BaseAmount - QuoteProduct.ManualDiscountAmount.GetValueOrDefault()) * TaxPercent);
                    decimal PricePerUnit = (decimal)(QuoteProduct.PricePerUnit.GetValueOrDefault() - QuoteProduct.VolumeDiscountAmount.GetValueOrDefault());
                    QuoteProduct.Tax = Tax; //depending on how you the parameters passed into CrmSvcUtil
                    QuoteProduct.Attributes["new_result"] = new Money(PricePerUnit); //same deal here
                    
                    //crm.UpdateObject(QuoteProduct);
                    //crm.SaveChanges();
                    //code not needed, the Plugin context will take care of this for you
                }
            }
        }
