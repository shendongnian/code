    [TestFixture]
    public class MappingTests2
    {
        [Test]
        public void AutoMapper_Configuration_IsValid()
        {
            UserViewConfiguration.Configure();
            Mapper.AssertConfigurationIsValid();
        }
        [Test]
        public void AutoMapper_MapsAsExpected()
        {
            UserViewConfiguration.Configure();
            Mapper.AssertConfigurationIsValid();
            var user = new User
                {
                    Email = "user1@email.com",
                    Hash = "1234Hash",
                    Name = "user1",
                    Salt = "1234Salt",
                    TaskTimes =
                        new Collection<TaskTime>
                            {
                                new TaskTime
                                    { Date = new DateTime(2012, 11, 01), Duration = new TimeSpan(0, 20, 1), Id = 1 },
                                new TaskTime
                                    { Date = new DateTime(2012, 11, 02), Duration = new TimeSpan(0, 20, 2), Id = 2 }
                            }
                };
            foreach (var taskTime in user.TaskTimes)
            {
                taskTime.User = user;
            }
            
            var userView = Mapper.Map<User, UserFull>(user);
            Assert.That(userView, Is.Not.Null);
            Assert.That(userView.Email, Is.EqualTo("user1@email.com"));
            Assert.That(userView.Name, Is.EqualTo("user1"));
            Assert.That(userView.TaskTimes, Is.Not.Null);
            Assert.That(userView.TaskTimes.Count, Is.EqualTo(2));
            var tt = userView.TaskTimes.FirstOrDefault(x => x.Id == 1);
            Assert.That(tt, Is.Not.Null);
            Assert.That(tt.Id, Is.EqualTo(1));
            Assert.That(tt.Date, Is.EqualTo(new DateTime(2012, 11, 01)));
            Assert.That(tt.Duration, Is.EqualTo(new TimeSpan(0, 20, 1)));
        }
    }
