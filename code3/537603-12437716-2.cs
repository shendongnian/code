    public void HeaderData(byte[] hex, ref TreeView treeview)
    {
        //First 4 Bytes = Mesh Version
        //Second 4 Bytes = Vertex Version
        byte[] meshVersion = hex.Take(4).ToArray();
        byte[] vertexVersion = hex.Skip(4).Take(4).ToArray();
        
        //Example: Do something with the Mesh Version Node
        treeView1.Nodes[1].Nodes[0].Nodes[0].Text = "Lorem ipsum";
    }
