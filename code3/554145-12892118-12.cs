    [Fact, NullCurrentPrincipal]
    public async Task 
        Returns_200_And_Role_With_Key() {
    
        // Arrange
        Guid key1 = Guid.NewGuid(),
             key2 = Guid.NewGuid(),
             key3 = Guid.NewGuid(),
             key4 = Guid.NewGuid();
    
        var mockMemSrv = ServicesMockHelper
            .GetInitialMembershipService();
    
        mockMemSrv.Setup(ms => ms.GetRole(
                It.Is<Guid>(k =>
                    k == key1 || k == key2 || 
                    k == key3 || k == key4
                )
            )
        ).Returns<Guid>(key => new Role { 
            Key = key, Name = "FooBar"
        });
    
        var config = IntegrationTestHelper
            .GetInitialIntegrationTestConfig(GetInitialServices(mockMemSrv.Object));
    
        using (var httpServer = new HttpServer(config))
        using (var client = httpServer.ToHttpClient()) {
    
            var request = HttpRequestMessageHelper
                .ConstructRequest(
                    httpMethod: HttpMethod.Get,
                    uri: string.Format(
                        "https://localhost/{0}/{1}", 
                        "api/roles", 
                        key2.ToString()),
                    mediaType: "application/json",
                    username: Constants.ValidAdminUserName,
                    password: Constants.ValidAdminPassword);
    
            // Act
            var response = await client.SendAsync(request);
            var role = await response.Content.ReadAsAsync<RoleDto>();
    
            // Assert
            Assert.Equal(key2, role.Key);
            Assert.Equal("FooBar", role.Name);
        }
    }
