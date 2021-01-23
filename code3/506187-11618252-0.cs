	ServerManager manager = new ServerManager();
	Site site = manager.Sites[siteName];
	foreach (XElement bindingNode in bindingsNode.Elements("Binding")) {
		Binding binding = site.Bindings.CreateElement();
		binding.BindingInformation = String.Format("{2}:{0}:{1}", bindingNode.Attribute("Port").Value, bindingNode.Value, bindingNode.Attribute("IP").Value);
		site.Bindings.Add(binding);
	}
	manager.CommitChanges();
