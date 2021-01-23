    public static explicit operator User(DTOUser dto)
    {
        return new User
        {
            Prop1 = dto.Prop1,
            Prop2 = dto.Prop2,
            ...
        }
    }
