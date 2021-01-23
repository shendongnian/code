    this.label1.MouseLeave += new System.EventHandler(this.HandleMouseLeave);
    this.MouseLeave += new System.EventHandler(this.HandleMouseLeave);
    
    private void HandleMouseLeave(object sender, EventArgs e)
    {
       Debug.WriteLine(string.Format("MouseLeave: {0}", DateTime.Now));
    }
