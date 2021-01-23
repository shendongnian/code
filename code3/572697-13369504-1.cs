    public ViewResult Index(int id)
    {
        PrePoolOwner entity = myservice.GetPrePoolOwner(id);
        PerPoolOwnerModel model = Mapper.Map<PerPoolOwnerModel>(entity);
        return View(model);
    }
