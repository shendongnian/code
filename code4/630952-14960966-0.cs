    public IEnumerable<IContentViewModel> BuildFrom(IEnumerable<NodeViewModel> nodes)
    {
        foreach (var nodeViewModel in nodes)
        {
            yield return BuildFrom(nodeViewModel);
            yield return BuildFrom(nodeViewModel.Children); // recursive call here
        }
    }
