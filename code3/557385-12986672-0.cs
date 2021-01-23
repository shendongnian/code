        private static IEdmModel GetEdmModel()
        {
            ODataModelBuilder modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.Namespace = "xxx";
            modelBuilder.EntitySet<ProductionOrder>("ProductionOrders");
            return modelBuilder.GetEdmModel();
        }
