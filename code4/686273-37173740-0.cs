    public static class DataSourceRequestExtensions
        {
            /// <summary>
            /// Finds a Filter Member with the "memberName" name and renames it for "newMemberName".
            /// </summary>
            /// <param name="request">The DataSourceRequest instance. <see cref="Kendo.Mvc.UI.DataSourceRequest"/></param>
            /// <param name="memberName">The Name of the Filter to be renamed.</param>
            /// <param name="newMemberName">The New Name of the Filter.</param>
            public static void RenameRequestFilterMember(this DataSourceRequest request, string memberName, string newMemberName)
            {
                foreach (var filter in request.Filters)
                {
                    var descriptor = filter as Kendo.Mvc.FilterDescriptor;
                    if (descriptor.Member.Equals(memberName))
                    {
                        descriptor.Member = newMemberName;
                    }
                } 
            }
        }
