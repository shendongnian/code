    for (int j = i + 1; j < AuthorCounter;)
    {
        if (AuthorGroupNode.Nodes[i].Text == AuthorGroupNode.Nodes[j].Text)
        {
            AuthorGroupNode.Nodes[j].Remove();
            AuthorCounter--;
        }
        else
        {
            j++;
        }
    }
