    void SetSubSubCProperties(SubSubC c, object cProperty, string bProperty, int id)
    {
        c.CProperty = cProperty;
        SetSubBProperties(c, bProperty, id);
    }
    void SetSubBProperties(SubB b, string bProperty, int id)
    {
        b.BProperty = bProperty;
        SetBaseAProperties(b, id);
    }
    void SetBaseAProperties(BaseA a, int id)
    {
        a.ID = id;
    }
