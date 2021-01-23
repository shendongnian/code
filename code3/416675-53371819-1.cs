            ContextMenuStrip CMS = new ContextMenuStrip()
            {
                Renderer = new ToolStripProfessionalRenderer(new submenuColorTable()),
                ShowImageMargin = false
            };
            ToolStripMenuItem TSMI = new ToolStripMenuItem("Button name")
            {
                BackColor = sampleMenuItem.BackColor,
                ForeColor = sampleMenuItem.ForeColor,
                Font = sampleMenuItem.Font,
                Margin = sampleMenuItem.Margin,
                Padding = sampleMenuItem.Padding,
                Size = sampleMenuItem.Size,
                TextAlign = sampleMenuItem.TextAlign,
                DropDown = CMS 
            };
            menuStrip.Items.Add(TSMI);
            
