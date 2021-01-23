    void Main()
    {
      Dictionary<int,int> skillList = new Dictionary<int,int>();
       
      skillList.Add(1,2);     skillList.Add(2,4);
      skillList.Add(3,6);     skillList.Add(4,8);
      skillList.Add(5,10);    skillList.Add(6,12);
      skillList.Add(7,14);
       
      DataTable userSkills = new DataTable();
      userSkills.Columns.Add("UserSkillId", typeof(int));
      userSkills.Columns.Add("SkillLevelId", typeof(int));
      userSkills.Columns.Add("UserId", typeof(int));
      userSkills.Columns.Add("SkillId", typeof(int));
    
      userSkills.Rows.Add(1, 1, 1, 1);
      userSkills.Rows.Add(2, 2, 2, 2);
      userSkills.Rows.Add(3, 3, 3, 3);
      userSkills.Rows.Add(4, 4, 4, 4);
      userSkills.Rows.Add(5, 5, 5, 5);
      
      var result = userSkills.AsEnumerable()
           .Join(skillList, 
                   user => user.Field<int>("SkillId"),
                   skill => skill.Key,
                   (user, skill) => new { UserID = user.Field<int>("UserId"),
                                          SkillId = skill.Key,
                                          SkillLevelId = skill.Value });
                                          
      result.Dump();
    }
