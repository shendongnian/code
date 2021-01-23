                using(var cnx = DbFactory.CreateConnection(Global.ConnectionString))
                {
                    using (var multi = cnx.QueryMultiple("mySchema.myStoredProc", new { communityId, categoryId }, commandType: CommandType.StoredProcedure))
                    {
                        var projectMembers = multi.Read<ProjectMember>().ToList();
                        var projects = multi.Read<Project>().ToList();
                        BindProjectMembers(projects, projectMembers);
                        return projects;
                    }
                }
