    try
	{
		db.InsertProcedureCall(id);
	}
	catch (SqlException e0)
	{
       // Won't catch
	}
	catch (EntityCommandExecutionException e1)
	{
		// Will catch
		var se = e1.InnerException as SqlException;
		var code = se.Number;
	}
	catch (Exception e2)
	{
       // Won't catch
	}
