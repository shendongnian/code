    protected async override void LoadChildren()
    {
        foreach (SpaceObject space in await Task.Run(() => DataManager.Instance.Read(mSpaceObject.ObjectId)))
            base.Childrens.Add(new SpaceObjectViewModel(space, this));
    }
