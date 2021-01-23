	public bool TryDelete(int id)
	{
		try
		{
			// Delete
			return true;
		}
		catch (SqlException ex)
		{
			if (ex.Number == 547) return false; // The {...} statement conflicted with the {...} constraint {...}
			throw; // other error
		}
	}
