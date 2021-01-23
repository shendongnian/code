    void btnGoToModeling_Click(object sender, EventArgs e)
    {
        IDictionary<string, object> packedState = new Dictionary<string, object>();
        packedState = _frmDatasheet.PackState();
        Broadcast(packedState);
    }
