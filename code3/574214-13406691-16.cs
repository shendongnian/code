    [Test]
    public void AutoMapper_Configuration_IsValid()
    {
        Mapper.Initialize(m => m.AddProfile<MVCF1Profile>());
        Mapper.AssertConfigurationIsValid();
    }
    [Test]
    public void AutoMapper_DriverMapping_IsValid()
    {
        Mapper.Initialize(m => m.AddProfile<MVCF1Profile>());
        Mapper.AssertConfigurationIsValid();
        var root = new RootObject
            {
                MRData = new MRData
                    {
                        StandingsTable = new StandingsTable
                            {
                                StandingsLists = new List<StandingsList>
                                    {
                                        new StandingsList()
                                            {
                                                season = "2012",
                                                DriverStandings = new List<DriverStanding>
                                                    {
                                                        new DriverStanding
                                                            {
                                                                points = "1",
                                                                Driver = new Driver
                                                                    {
                                                                        familyName = "Button",
                                                                        givenName = "Jenson"
                                                                    }
                                                            },
                                                        new DriverStanding
                                                            {
                                                                points = "2",
                                                                Driver = new Driver
                                                                    {
                                                                        familyName = "Zip",
                                                                        givenName = "Jackson"
                                                                    }
                                                            }
                                                    }
                                            },
                                        new StandingsList()
                                            {
                                                season = "2011",
                                                DriverStandings = new List<DriverStanding>
                                                    {
                                                        new DriverStanding
                                                            {
                                                                points = "3",
                                                                Driver = new Driver
                                                                    {
                                                                        familyName = "Silly",
                                                                        givenName = "ImReally"
                                                                    }
                                                            },
                                                        new DriverStanding
                                                            {
                                                                points = "4",
                                                                Driver = new Driver
                                                                    {
                                                                        familyName = "Not",
                                                                        givenName = "NoYoure"
                                                                    }
                                                            }
                                                    }
                                            }
                                    }
                            }
                    }
            };
        var result = root.MRData.StandingsTable.StandingsLists.SelectMany(
            sl => sl.DriverStandings
                        .Select(Mapper.Map<DriverStanding, Models.DriverResults>)
                        .Select(dr => Mapper.Map(sl, dr))
            );
            
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count(), Is.EqualTo(4));
        var driverResults = result.FirstOrDefault(x => x.Points == "1");
        Assert.That(driverResults, Is.Not.Null);
        Assert.That(driverResults.Season, Is.EqualTo("2012"));
        Assert.That(driverResults.Driver, Is.Not.Null);
        Assert.That(driverResults.Driver.Count, Is.EqualTo(1));
        Assert.That(driverResults.Driver[0].FirstName, Is.EqualTo("Jenson"));
        Assert.That(driverResults.Driver[0].LastName, Is.EqualTo("Button"));
        driverResults = result.FirstOrDefault(x => x.Points == "2");
        Assert.That(driverResults, Is.Not.Null);
        Assert.That(driverResults.Season, Is.EqualTo("2012"));
        Assert.That(driverResults.Driver, Is.Not.Null);
        Assert.That(driverResults.Driver.Count, Is.EqualTo(1));
        Assert.That(driverResults.Driver[0].FirstName, Is.EqualTo("Jackson"));
        Assert.That(driverResults.Driver[0].LastName, Is.EqualTo("Zip"));
        driverResults = result.FirstOrDefault(x => x.Points == "3");
        Assert.That(driverResults, Is.Not.Null);
        Assert.That(driverResults.Season, Is.EqualTo("2011"));
        Assert.That(driverResults.Driver, Is.Not.Null);
        Assert.That(driverResults.Driver.Count, Is.EqualTo(1));
        Assert.That(driverResults.Driver[0].FirstName, Is.EqualTo("ImReally"));
        Assert.That(driverResults.Driver[0].LastName, Is.EqualTo("Silly"));
        driverResults = result.FirstOrDefault(x => x.Points == "4");
        Assert.That(driverResults, Is.Not.Null);
        Assert.That(driverResults.Season, Is.EqualTo("2011"));
        Assert.That(driverResults.Driver, Is.Not.Null);
        Assert.That(driverResults.Driver.Count, Is.EqualTo(1));
        Assert.That(driverResults.Driver[0].FirstName, Is.EqualTo("NoYoure"));
        Assert.That(driverResults.Driver[0].LastName, Is.EqualTo("Not"));
    }
