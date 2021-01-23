        foreach (var c in children)
        {
            if (c.ParentId == parents[0].ParentId)
            {
                c.Parent = parents[0];
                if (!parents[0].Childs.Contains(c))
                    parents[0].Childs.Add(c);
            }
        }
