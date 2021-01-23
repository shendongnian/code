    [HttpPost]
    public int Relate(RelateViewModel model)
    {
        return relationshipRepository.Add(model.PrimaryEntityId, model.RelatedEntityId);
    }
