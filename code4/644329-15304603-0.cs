    private List<Caster> BestCasters()
    {
        var witches = casters.Where(x => x.TypeOfCaster == 0).ToList();
        var fairies = casters.Where(x => x.TypeOfCaster == 1).ToList();
        int witchesMax = witches.Max(x => x.SpellPower);
        int fairiesMax = fairies.Max(x => x.SpellPower);
        var temp = witches.Where(x => x.SpellPower == witchesMax).ToList();
        temp.AddRange(fairies.Where(x => x.SpellPower == fairiesMax)); 
        return temp.OrderBy(x => x.TypeOfCaster).ThenBy(y => y.CasterName).ToList();
    }
