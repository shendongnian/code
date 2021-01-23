    public static ParentViewModel AsViewModel(Parent parent)
    {
        var childViewModels = parent.Children.Select(AsViewModel).ToList();
        return new ParentViewModel { Id = parent.Id, Children = childViewModels };
    }
    public static ChildViewModel AsViewModel(Child child)
    {
        var toyViewModels = child.Toys.Select(AsViewModel).ToList();
        return new ChildViewModel { Id = child.Id, Toys = toyViewModels };
    }
    public static ToyViewModel AsViewModel(Toy toy)
    {
        return new ToyViewModel { Id = toy.Id, Name = toy.Name };
    }
