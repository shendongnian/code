                 @{
                    var roles = (SimpleRoleProvider)Roles.Provider;
                    string[] strroles = roles.GetAllRoles();
                    string[] userorles = roles.GetRolesForUser(Model.UserName);
                    foreach (string strrole in strroles)
                    {
                        bool isinrol = false;
                        foreach (string struserroles in userorles)
                        {
                            if (strrole == struserroles)
                            {
                                isinrol = true;
                            }
                        }
                        if(isinrol)
                        {
                            <input type="checkbox" id="roles[]"  name="roles" value="@strrole" checked="checked" /> @strrole <br />
                        }
                        else
                        {
                            <input type="checkbox" id="roles[]" name="roles"  value="@strrole"/> @strrole <br />
                        }
                    }
                  }
