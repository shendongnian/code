    Bool isVisible = userOrgs.Any(delegate(string x)
                                  {
                                      String y = txtOrg.Text;
                                      if (y.EndsWith("%"))
                                      {
                                          return x.StartsWith(y.TrimEnd('%'));
                                      }
                                      if (x.EndsWith("%"))
                                      {
                                          return y.StartsWith(x.Trim('%'));
                                      }
                                      return x == y;
                                  }
