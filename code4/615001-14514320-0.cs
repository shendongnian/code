	string filename = "Test.xls";
	string password = "password";
	Excel._Application app = new Excel.Application();
	Excel._Workbook workbook = app.Workbooks.Open(Filename: filename, Password: password);
	if (workbook.HasVBProject)
	{
		VBProject project = workbook.VBProject;
		foreach (VBComponent component in project.VBComponents)
		{
			if (component.Type == vbext_ComponentType.vbext_ct_StdModule ||
				component.Type == vbext_ComponentType.vbext_ct_ClassModule)
			{
				CodeModule module = component.CodeModule;
				string[] lines =
					module.get_Lines(1, module.CountOfLines).Split(
						new string[] { "\r\n" },
						StringSplitOptions.RemoveEmptyEntries);
				for (int i = 0; i < lines.Length; i++)
				{
					if (lines[i].Contains("A1"))
					{
						lines[i] = lines[i].Replace("A1", "D1");
						module.ReplaceLine(i + 1, lines[i]);
					}
				}
			}
		}
	}
	workbook.Save();
	workbook.Close();
	app.Quit();
