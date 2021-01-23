    /// <summary>
    /// The deletes an and all children, but does not commit changes to the db.
    ///  - MH @ 2016/08/15 14:42
    /// </summary>
    /// <param name="parent">
    /// The cms object.
    /// </param>
    private void DeleteObjectAndChildren(Object parent)
    {
        // Deletes One-to-Many Children
        if (parent.Things != null && parent.Things.Count > 0)
        {
            this.db.Things.RemoveRange(parent.Things);
        }
        // Deletes Self Referenced Children
        if (parent.Children != null && parent.Children.Count > 0)
        {
            foreach (var child in parent.Children)
            {
                this.DeleteObjectAndChildren(child);
            }
            this.db.Objects.RemoveRange(parent.Children);
        }
        // Deletes the Parent Element
        this.db.CmsObjects.Remove(parent);
    }
