            HostSurfaceManager hsm = new HostSurfaceManager();
            HostControl hc = hsm.GetNewHost(typeof(Form), LoaderType.CodeDomDesignerLoader);
            var l = new Label() { Text = "TEST!!!!" };
            hc.DesignerHost.Container.Add(l);
            richTextBox1.Text = ((CodeDomHostLoader)hc.HostSurface.Loader).GetCode("C#");
