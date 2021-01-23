    List<LightEntity> lights = new List<LightEntity>();
    foreach (Entity ent in Entities)
    {
        LightEntity le = ent as LightEntity
        if(le != null)
        {
            lights.Add(le);
        }
    }
