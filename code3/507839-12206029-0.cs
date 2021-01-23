	error_list = new ErrorListProvider(this.Site);
		error_list.ProviderName = "MyLanguageService Errors";
		error_list.ProviderGuid = new Guid(this.errorlistGUIDstring.);
	}
	ErrorTask task = new ErrorTask();
	task.Document = filename;
	task.CanDelete = true;
	task.Category = TaskCategory.CodeSense;
	task.Column = column;
	task.Line = line;
	task.Text = message;
	task.ErrorCategory = TaskErrorCategory.Error;
	task.Navigate += NavigateToParseError;
	error_list.Tasks.Add(task);
