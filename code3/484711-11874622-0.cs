	public partial class EntityContext
	{
		public override int SaveChanges(System.Data.Objects.SaveOptions options)
		{
			var modified = this.ObjectStateManager.GetObjectStateEntries(EntityState.Modified | EntityState.Added); // Get the list of things to update
			var result = base.SaveChanges(options); // Call the base SaveChanges, which clears that list.
			using (var context = new WebDataContext()) // This is the second database context.
			{
				foreach (var obj in modified)
				{
					var table = obj.Entity as IAdvantageWebTable;
					if (table != null)
					{
						table.UpdateWeb(context); // This is IAdvantageWebTable.UpdateWeb(), which calls all the existing logic I've had in place for years.
					}
				}
				context.SubmitChanges();
			}
			return result;
		}
	}
