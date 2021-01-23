	var expr =
		Expression.Lambda<Func<Program, string>>(
			Expression.MakeIndex(
					Expression.Property(
						parameter,
						typeof(Program).GetProperty("x")),
					typeof(List<string>).GetProperty("Item"),
					new[] { Expression.Constant(0) }),
			parameter);
