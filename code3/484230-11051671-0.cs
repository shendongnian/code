    public PopupWindow(Control content) {
      // Basic setup...
      // this.AutoSize = false;
      // this.DoubleBuffered = true;
      // this.ResizeRedraw = true;
      // this.BackColor = content.BackColor;
      this._content = content;
      this._host = new ToolStripControlHost(content);
      this._host.Margin = new Padding(0);
      this._host.Padding = new Padding(0);
      this.Padding = new Padding(0);
      this.Margin = new Padding(0);
      //Positioning and Sizing
      this.MinimumSize = content.MinimumSize;
      this.MaximumSize = content.Size;
      this.Size = content.Size;
      content.Location = Point.Empty;
      //Add the host to the list
      this.Items.Add(this._host);
    }
