    public static TUser FindById<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId) where TUser : class, IUser<TKey> where TKey : IEquatable<TKey>
    {
		if (manager == null)
		{
			throw new ArgumentNullException("manager");
		}
		return AsyncHelper.RunSync<TUser>(() => manager.FindByIdAsync(userId));
	}
    public static bool IsInRole<TUser, TKey>(this UserManager<TUser, TKey> manager, TKey userId, string role) where TUser : class, IUser<TKey> where TKey : IEquatable<TKey>
	{
		if (manager == null)
		{
			throw new ArgumentNullException("manager");
		}
		return AsyncHelper.RunSync<bool>(() => manager.IsInRoleAsync(userId, role));
	}
