		using System.Collections.Generic;
		using System.Web.Optimization;
		using BundleTransformer.Core.Builders;
		using BundleTransformer.Core.Orderers;
		using BundleTransformer.Core.Transformers;
		using BundleTransformer.Core.Translators;
		using BundleTransformer.Less.Translators;
		public class BundleConfig
		{
			public static void RegisterBundles(BundleCollection bundles)
			{
				var nullBuilder = new NullBuilder();
				var nullOrderer = new NullOrderer();
				var lessTranslator = new LessTranslator
				{
					GlobalVariables = "my-variable='Hurrah!'",
					ModifyVariables = "font-family-base='Comic Sans MS';body-bg=lime;font-size-h1=50px"
				};
				var cssTransformer = new CssTransformer(new List<ITranslator>{ lessTranslator });
				var commonStylesBundle = new Bundle("~/Bundles/BootstrapStyles");
				commonStylesBundle.Include(
				   "~/Content/less/bootstrap-3.1.1/bootstrap.less");
				commonStylesBundle.Builder = nullBuilder;
				commonStylesBundle.Transforms.Add(cssTransformer);
				commonStylesBundle.Orderer = nullOrderer;
				bundles.Add(commonStylesBundle);
			}
		}
		
