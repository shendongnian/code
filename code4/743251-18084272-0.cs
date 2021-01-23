    public UserRoleMap()
    {
      Table("tb_user_role");
      CompositeId()
                .KeyReference(x => x.User, "intID")
                .KeyReference(x => x.Role, "intRole");
      Map(f => f.IsActive).Column("btActive").Not.Nullable();
    }
