    void AddGame(string title)
    {
        if(InvokeRequired)
        {
            Invoke(new MethodInvoker(delegate() { AddGame(title); }));
        }
        else
        {
            AddGameNodeToTreeView(title); // add new game node to desired place in TreeView
            nodesCount++; // increase node counter
            toolStripStatusLabel1.Text = "Number of games in database: " + nodesCount;
        }  
    }
