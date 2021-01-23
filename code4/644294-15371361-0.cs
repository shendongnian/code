    public IQueryable<ViaturaFuncao> FindByNome(string names)
    {
        return Uow.allProfessionals.LikeBy(names.Trim().Split(' '),
                                           (professional, nameProfessional) =>
                                           professional.Where(
                                               f => f.Name.ToLower().Contains(nameProfessional.ToLower())));
    }
