    User user = new User
                {
                    FirstName = "Tex",
                    Surname = "Murphy",
                    AddedDateTime = DateTime.Now < Something? DateTime.Now : SomeOtherValue,
                    ModifiedDateTime = DateTime.Now < Something? DateTime.Now : SomeOtherValue
                };
