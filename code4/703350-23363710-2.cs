		using System.Web.Optimization;
		using BundleTransformer.Core.Orderers;
		using BundleTransformer.Core.Bundles;
		public class BundleConfig
		{
			public static void RegisterBundles(BundleCollection bundles)
			{
				var nullOrderer = new NullOrderer();
				const string beforeLessCodeToInject = @"@my-variable: 'Hurrah!';";
				const string afterLessCodeToInject = @"@font-family-base: 'Comic Sans MS';
	@body-bg: lime;
	@font-size-h1: 50px;";
				var commonStylesBundle = new CustomStyleBundle("~/Bundles/BootstrapStyles");
				commonStylesBundle.Include(
				   "~/Content/less/bootstrap-3.1.1/bootstrap.less",
				   new InjectContentItemTransform(beforeLessCodeToInject, afterLessCodeToInject));
				commonStylesBundle.Orderer = nullOrderer;
				bundles.Add(commonStylesBundle);
			}
		}
