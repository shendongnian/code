    public SimpleTree<MailData> CreateTree(List<MailData> mails)
    {
        mails.Sort((m1, m2) => m1.TopicId == m2.TopicId ? m2.CreationDate.CompareTo(m1.CreationDate) : m1.TopicId.CompareTo(m2.TopicId));
    
        var tree = new SimpleTree<MailData>();
    
        var i = 0;
        while (i < mails.Count)
        {
            var node = tree.Children.Add(mails[i]);
            var topicId = mails[i].TopicId;
            var start = i + 1;
            while (start < mails.Count 
                && !string.IsNullOrEmpty(topicId) 
                && !string.IsNullOrEmpty(mails[start].TopicId) 
                && mails[start].TopicId.StartsWith(topicId))
            {
                node.Children.Add(mails[start]);
                start++;
            }
            i = start;
        }
    
        // Handle email where TopicId are different, but ParentId is filled with correct value
        for (int j = tree.Children.Count - 1; j >= 0; j--)
        {
            var child = tree.Children[j];
            if (child.Children.Count == 0 && !string.IsNullOrEmpty(child.Value.ParentId))
            {
                var parentNode = tree.FindNode(s => s != null && s.MessageId == child.Value.ParentId);
                if (parentNode != null && parentNode != child)
                    parentNode.Children.Add(child);
            }
        }
    
        return tree;
    }
