    public BasePersonViewModel obj;
    public SomeViewModel(Person data) {
        if (data is SuperHero)
            obj = new BaseSuperHeroViewModel (data);
        else
            obj = new BasePersonViewModel(data);
    }
