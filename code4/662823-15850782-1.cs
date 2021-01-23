    var roles = new List<Role>
    {
        new Role { Name = siteCode+"_role1"  },
        new Role { Name = siteCode+"_role22"  },
        new Role { Name = siteCode+"_role1324"  },
    };
    
    Assert.AreEqual(2, roles.Where(actualExpression.Compile()).Count()); //test the number of roles returned is as expected
