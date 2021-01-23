	public static class SqlExtensions {
		public static SqlConnection OpenAndReturn(this SqlConnection con) {
			try {
				con.Open();
				return con;
			} catch {
				if(con != null)
					con.Dispose();
				throw;
			}
		}
	}
