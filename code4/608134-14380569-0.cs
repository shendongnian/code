    dynamic test = t.InvokeMember(table,
                            BindingFlags.DeclaredOnly |
                            BindingFlags.Public | BindingFlags.NonPublic |
                            BindingFlags.Instance | BindingFlags.GetProperty, null, context, new object[0]);
                
                ((IQueryable)test).AsQueryable().Where(condition).Load();
                results.ItemsSource = test.Local;
