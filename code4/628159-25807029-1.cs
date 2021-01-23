	var bundle = new ScriptBundle("~/test")
		.Add("~/Scripts/jquery/jquery-{version}.js")
		.Add("~/Scripts/lib*")
		.Add("~/Scripts/model.js")
		);
	var includes = bundle.EnumerateIncludes();
	var files = bundle.EnumerateFiles();
