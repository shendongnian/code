    protected bool IsUserInLocalGroup(string userName, string group)
		{
			using (DirectoryEntry computerEntry = new DirectoryEntry("WinNT://{0},computer".FormatWith(Environment.MachineName)))
			using(DirectoryEntry groupEntry = computerEntry.Children.Find(group, "Group"))
			{
				foreach (object o in (IEnumerable)groupEntry.Invoke("Members"))
				{
					using (DirectoryEntry entry = new DirectoryEntry(o))
					{
						if (entry.SchemaClassName.Equals("User", StringComparison.OrdinalIgnoreCase) && entry.Name.Equals(userName, StringComparison.OrdinalIgnoreCase))
						{
							return true;
						}
					}
				}
				return false;
			}
		}
