    public GroupVM Group
    {
        get
        {
           if(groupVM == null)
           {
                 groupVM = Prisma.Web.Models.Factories.ViewModelFactory<Prisma.BO.Group>.ToViewModel<GroupVM>(this._Model.Group);
            }
            return groupVM;
        }
    }
