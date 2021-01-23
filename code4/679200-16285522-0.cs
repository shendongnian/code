	using System;
	using System.Collections.Specialized;
	using System.Configuration;
	void methodname()
	{
		AppSettingsReader reader = new AppSettingsReader();
		string txtFilePath  = (string)reader.GetValue("txtFilePath", typeof(string));
	}
