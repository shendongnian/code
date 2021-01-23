    public Node DeepNodeClone(TreeNode src)
    {
    MemoryStream ms = new MemoryStream();
    BinaryFormatter bf = new BinaryFormatter();
    bf.Serialize(ms, src);
    ms.Position = 0;
    object obj = bf.Deserialize(ms);
    ms.Close();
    return (TreeNode)obj;
    }
