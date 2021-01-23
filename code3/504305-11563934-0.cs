    public IEnumerable<Node> GetAllWithTag(int tagId)
    {
        return _applicationUnitOfWork.GetSession().QueryOver<Node>()
            .JoinQueryOver<Tag>(n => n.Tags)
                .Where(t => t.Id == tagId)
                .List<Node>();
    }
