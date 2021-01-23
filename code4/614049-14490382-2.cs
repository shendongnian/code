	namespace My.Namespace
	{
		public class MyItemProvider : Sitecore.Data.Managers.ItemProvider
		{
			protected override void Sort(Sitecore.Collections.ItemList items, Sitecore.Data.Items.Item owner)
			{
				try
				{
					base.Sort(items, owner);
				}
				catch (System.Exception exc)
				{
					Sitecore.Diagnostics.Log.Error("Exception while sorting children of " + owner.Paths.FullPath, exc, this);
				}
			}
		}
	}
