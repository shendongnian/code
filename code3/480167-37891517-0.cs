		public bool CreateDirectoryRecursively(string path)
		{
			try
			{
				string[] pathParts = path.Split('\\');
				for (var i = 0; i < pathParts.Length; i++)
				{
					// Correct part for drive letters
					if (i == 0 && pathParts[i].Contains(":"))
					{
						pathParts[i] = pathParts[i] + "\\";
					} // Do not try to create last part if it has a period (is probably the file name)
					else if (i == pathParts.Length-1 && pathParts[i].Contains("."))
					{
						return true;
					}
					if (i > 0) { 
						pathParts[i] = Path.Combine(pathParts[i - 1], pathParts[i]);
					}
					if (!Directory.Exists(pathParts[i]))
					{
						Directory.CreateDirectory(pathParts[i]);
					}
				}
				return true;
			}
			catch (Exception ex)
			{
				var recipients = _emailErrorDefaultRecipients;
				var subject = "ERROR: Failed To Create Directories in " + this.ToString() + " path: " + path;
				var errorMessage = Error.BuildErrorMessage(ex, subject);
				Email.SendMail(recipients, subject, errorMessage);
				Console.WriteLine(errorMessage);
				return false;
			}
		}
