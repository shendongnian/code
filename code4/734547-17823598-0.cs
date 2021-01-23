    private void TreeBroswer_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
    {
        var preview = new PictureBox { ImageLocation = e.Node.FullPath };
        // Display preview
    }
