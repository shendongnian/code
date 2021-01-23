    //load assembly.
                var assembly = Assembly.LoadFile(Request.PhysicalApplicationPath + "bin\\SystemTest.dll");
                //get testfixture classes in assembly.
                var testTypes = from t in assembly.GetTypes()
                    let attributes = t.GetCustomAttributes(typeof(NUnit.Framework.TestFixtureAttribute), true)
                    where attributes != null && attributes.Length > 0
                    orderby t.Name
                        select t;
                foreach (var type in testTypes)
                {
                    //get test method in class.
                    var testMethods = from m in type.GetMethods()
                                      let attributes = m.GetCustomAttributes(typeof(NUnit.Framework.TestAttribute), true)
                        where attributes != null && attributes.Length > 0
                        orderby m.Name
                        select m;
                    foreach (var method in testMethods)
                    {
                        tests.Add(method.Name);
                    }
                }
