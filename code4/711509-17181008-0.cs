    DataTable skilllist = ds.Tables["UserSkills"];
    var result = skilllist.AsEnumerable()
            .Join(skilldictionary,
                item => item.Field<Int32>("SkillId").ToString()+"-"+item.Field<Int32>("SkillLeveId").ToString(),
                dictItem => dictItem.Key,
                (item, dictItem) => new {
                                          UserID : item.Field<Int32>("UserId"),
                                          Skills : dictItem.Value
                                        });
