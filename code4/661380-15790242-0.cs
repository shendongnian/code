    mock.Setup(users => users.GetListAll(It.IsAny<List<int>>()))
                .Returns<List<int>>(ids =>
                    {
                        return _users.Where(user => ids.Contains(user.Id)).ToList();
                    });
