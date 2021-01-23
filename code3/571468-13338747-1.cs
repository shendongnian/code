    [TestFixture]
    public class MapperTests
    {
        [Test]
        public void Mapping_Configuration_IsValid()
        {
            AutoMapperConfig.Configure();
            Mapper.AssertConfigurationIsValid();
        }
        [Test]
        public void Mapping_TestItems_MappedOK()
        {
            AutoMapperConfig.Configure();
            Mapper.AssertConfigurationIsValid();
            var data = new[]
                {
                    new X
                        {
                            A = "A1",
                            B = new[]
                                {
                                    new Y
                                        {
                                            C = "A1C1",
                                            D = new[]
                                                {
                                                    new Z
                                                        {
                                                            E = "A1C1E1",
                                                            F = "A1C1F1"
                                                        },
                                                    new Z
                                                        {
                                                            E = "A1C1E2",
                                                            F = "A1C1F2"
                                                        },
                                                }
                                        },
                                    new Y
                                        {
                                            C = "A1C2",
                                            D = new[]
                                                {
                                                    new Z
                                                        {
                                                            E = "A1C2E1",
                                                            F = "A1C2F1"
                                                        },
                                                    new Z
                                                        {
                                                            E = "A1C2E2",
                                                            F = "A1C2F2"
                                                        },
                                                }
                                        }
                                }
                        }
                };
            var rc = data.SelectMany(
                x => x.B.SelectMany(
                    y => y.D
                        .Select(Mapper.Map<Z, Destination>)
                        .Select(z => Mapper.Map(y, z))
                    )
                    .Select(y => Mapper.Map(x, y))
                );
            Assert.That(rc, Is.Not.Null);
            Assert.That(rc.Count(), Is.EqualTo(4));
            var item = rc.FirstOrDefault(x => x.F == "A1C2F2");
            Assert.That(item, Is.Not.Null);
            Assert.That(item.A, Is.EqualTo("A1"));
            Assert.That(item.C, Is.EqualTo("A1C2"));
            Assert.That(item.E, Is.EqualTo("A1C2E2"));
            Assert.That(item.F, Is.EqualTo("A1C2F2"));
        }
    }
