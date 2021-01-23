	partial class MartinMulderExtensions {
		public static Type[] GetDesiredTypes() {
			return (
				from type in MartinMulderExtensions.GetMscorlibTypes()
				.Select(x => x.GetRetrievableTypes())
				.Aggregate(Enumerable.Union)
