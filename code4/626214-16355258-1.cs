    if (api.ActionDescriptor.ControllerDescriptor.ControllerType.Namespace != null)
        {
            var versionName = api.ActionDescriptor.ControllerDescriptor.ControllerType.Namespace.Replace(".Controllers", "").Split('.').Last();
            api.RelativePath = api.RelativePath.Replace("v???", versionName);
        }
