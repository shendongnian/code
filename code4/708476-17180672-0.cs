            BundleCollection bundles = new BundleCollection();
            bundles.Add(new StyleBundle("~/bundles/css").Include("~/Styles/image.css", "~/Styles/nested/image2.css"));
            OptimizationSettings config = new OptimizationSettings() {
                ApplicationPath = TestContext.DeploymentDirectory,
                BundleTable = bundles
            };
            BundleResponse response = Optimizer.BuildBundle("~/bundles/css", config);
