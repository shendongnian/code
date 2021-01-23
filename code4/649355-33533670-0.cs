    public void DeleteItemExecute ()
    {
        DesignObjectViewModel node = this.SelectedNode;    // Action is on selected item
        DocStructureManagement.DeleteNode(node.DesignObject); // Remove from application
        node.Remove();                                // Remove from view model
        Controller.UpdateDocument();                  // Signal document has changed
    }
