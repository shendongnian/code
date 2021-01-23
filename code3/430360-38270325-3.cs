        // using System.Security.Principal;
        GenericPrincipal FakeUser(string userName)
        {
            var fakeIdentity = new GenericIdentity(userName);
            var principal = new GenericPrincipal(fakeIdentity, null);
            return principal;
        }
