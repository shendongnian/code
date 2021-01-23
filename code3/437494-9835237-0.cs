	[Guid("EEB4C1AE-4DB2-4bdb-86D4-A429B27496A3")]
	public interface IAXFarCards
	{
		[DispId(1)]
		void InitDbConnection([In, MarshalAs(UnmanagedType.BStr)] string connectionString);
		[DispId(2)]
		[return: MarshalAs(UnmanagedType.I4)]
		int GetCardInfo(
			[In, MarshalAs(UnmanagedType.BStr)]             string card,
			[In, MarshalAs(UnmanagedType.VariantBool)]      bool   isTemplate,
			[In, MarshalAs(UnmanagedType.I4)]               int    cashDeskId,
			[Out, MarshalAs(UnmanagedType.VariantBool)] out bool   isActive,
			[Out, MarshalAs(UnmanagedType.I4)]          out int    discountNumber,
			[Out, MarshalAs(UnmanagedType.I8)]          out Int64  amount,
			[In, Out, MarshalAs(UnmanagedType.BStr)]    ref string ownerName,
			[In, Out, MarshalAs(UnmanagedType.I4)]      ref int    clientId
			);
