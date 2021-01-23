    _chosenUser = _user.GetType()
                        .GetProperties()
                        .Select(p =>
                            {
                                object value = p.GetValue(_user, null);
                                return value == null ? null : value.ToString();
                            })
                        .ToArray();
