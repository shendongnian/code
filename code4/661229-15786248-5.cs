    var someclass = new SomeClass();
            someclass.GetType()
                .GetField("_studentID",
                    System.Reflection.BindingFlags.NonPublic |
                     System.Reflection.BindingFlags.Instance)
                .SetValue(someclass, 12);
