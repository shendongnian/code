    public ViewResult Index(int id)
    {
        PrePoolOwner entity = myservice.GetPrePoolOwner(id);
        PrePoolOwnerModel model = Mapper.Map<PrePoolOwnerModel>(entity);
        return View(model);
    }
