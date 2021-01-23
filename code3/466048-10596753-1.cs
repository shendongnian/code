          userDataSource.Insert(new UserEntity(
          GetPartitionKeyFromUsername(username).ToString(),
          String.Empty)
                {
                    Username = username,
                    Password = EncodePassword(password),
                    CreationDate = DateTime.Now,
                    IsDeleted = DefaultValues.IsDeleted,
                    IsLockedOut = DefaultValues.IsLockedOut,
                    IsApproved = DefaultValues.IsApproved,
                    ApplicationName = applicationName,
                    Email = email,
                    PasswordQuestion = passwordQuestion,
                    PasswordAnswer = passwordAnswer,
                    Gender = DefaultValues.Gender,
                    LastProfileUpdatedDate = DateTime.Now,
                    LastActivityDate = DateTime.Now,
                    LastPasswordChangedDate = DateTime.Now,
                    LastLoginDate = new DateTime(1970, 1, 1),
                    LastLockedOutDate = new DateTime(1970, 1, 1),
                    FailedPasswordAttemptWindowStart = new DateTime(1970, 1, 1),
                    FailedPasswordAnswerAttemptWindowStart = new DateTime(1970, 1, 1),
                    Birthday = new DateTime(1970, 1, 1),
                    Roles = Roles(username),
                    ID_client = IDuser(username)
                });
