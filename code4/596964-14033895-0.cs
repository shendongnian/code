        Label newlabel = new Label();
        newlabel.Text = "Hello World";
        newlabel.Width = 300;
        ToolStripControlHost tsHost = new ToolStripControlHost(newlabel);
        contextMenuStrip1.Items.Add(tsHost);
