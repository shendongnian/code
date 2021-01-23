    SearchResult result = directorySearcher.FindOne();
            if (result == null)
                return new LocalPermissionEntry(accessRule);
            ResultPropertyValueCollection userValueCollection = result.Properties["objectClass"];
            // check if the entry is a group or a user.
            if (userValueCollection.Contains("group"))
                return new GroupPermissionEntry(accessRule);
            if (userValueCollection.Contains("person") || userValueCollection.Contains("user"))
                return new UserPermissionEntry(accessRule);
            return new LocalPermissionEntry(accessRule);
