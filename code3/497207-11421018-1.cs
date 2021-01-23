    [Test]
    public void Should_be_able_to_route_to_gettables_action_in_databaseschemaexplorercontroller()
    {
        const string url = "~/DatabaseSchemaExplorer/Tables/DatabaseType/Provider/DataSource/DatabaseName";
        _httpContextMock.Expect(c => c.Request.AppRelativeCurrentExecutionFilePath).Return(url);
        var routeData = _routes.GetRouteData(_httpContextMock);
        Assert.IsNotNull(routeData, "Should have found the route");
        Assert.AreEqual("DatabaseSchemaExplorer", routeData.Values["Controller"]);
        Assert.AreEqual("Tables", routeData.Values["action"]);
        Assert.AreEqual("DatabaseType", routeData.Values["databaseType"]);
        Assert.AreEqual("Provider", routeData.Values["provider"]);
        Assert.AreEqual("DataSource", routeData.Values["dataSource"]);
        Assert.AreEqual("DatabaseName", routeData.Values["databaseName"]);
    }
