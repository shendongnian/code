    protected override void Seed(ApplicationDbContext context) {
            var gender = new[] { Gender.NotSpecified, Gender.Male, Gender.Female };
            var dbGender = context.Gender.ToList();
            for (byte i = 0; i < gender.Length; i++) {
                if (dbGender.FirstOrDefault(x => x.Name == gender[i]) != null) {
                    context.Gender.Add(new Gender {
                        Id = i,
                        Name = gender[i]
                    });
                }
            }
        }
