        public void EditProfileInfo(ProfileInfo profileInfo)
        {
            using (var context = new TestContext())
            {
                context.EditEntity(profileInfo, TypeOfEditEntityProperty.Ignore, nameof(profileInfo.Name), nameof(profileInfo.Family));
            }
        }
