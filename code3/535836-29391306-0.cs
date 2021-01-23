    try
    {
        var directoryNode = new TreeNode( directoryInfo.Name );
        foreach ( var directory in directoryInfo.GetDirectories() )
            directoryNode.Nodes.Add( CreateDirectoryNode( directory ) );
        foreach ( var file in directoryInfo.GetFiles() )
            directoryNode.Nodes.Add( new TreeNode( file.Name ) );
        return directoryNode;
    }
    catch ( System.UnauthorizedAccessException )
    {
        return new TreeNode( "Unavailable Node" );
    }
    catch ( System.IO.PathTooLongException )
    {
        return new TreeNode( "Unavailable Node" );
    }
