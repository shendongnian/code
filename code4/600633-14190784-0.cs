		using System.Xml.Linq;
		public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
            string targetDirectory = Context.Parameters["targetdir"];
            string ServerName = Context.Parameters["ServerName"];
            System.Diagnostics.Debugger.Break();
            string configPath = string.Format("{0myapp.exe.config", targetDirectory);
			XElement root = XElement.Load(configPath);
			var endPointElements = root.Descendants("endpoint");
			foreach(var element in endPointElements)
			{
				element.Attribute("address").Value = ServerName;
			}
			root.Save(configPath);
        }
    }
