	public class program
	{
		public program()
		{
			using (DBOperations dbOperations = new DBOperations())
			{
				dbOperations.UpdateDB(); // Update the database no commit.
				dbOperations.RollbackTransaction(); // Rollback.
				dbOperations.UpdateDB(); // Update the database no commit.
				dbOperations.RollbackTransaction(); // Rollback.
			} // Commit on Dispose.
		}
	}
