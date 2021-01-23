			catch (Exception ex)
			{
				var lines = ex.StackTrace
					.Split(new[] {Environment.NewLine}, StringSplitOptions.None)
					.Where(l => Regex.IsMatch(l, @"([^\)]*\)) in (.*):line (\d)*$"));
				var userStackTrace = string.Join(Environment.NewLine, lines);
			}
