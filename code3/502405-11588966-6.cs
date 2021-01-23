				VisualBasicSettings vbs =
					VisualBasic.GetSettings(root) ?? new VisualBasicSettings();
				var namespaces = (from type in assembly.GetTypes()
								  select type.Namespace).Distinct();
				var fullName = assembly.FullName;
				foreach (var name in namespaces)
				{
					var import = new VisualBasicImportReference()
					{
						Assembly = fullName,
						Import = name
					};
					vbs.ImportReferences.Add(import);
				}
				VisualBasic.SetSettings(root, vbs);
