            var myobjects = new List<System.Security.Cryptography.MD5>();
            for (var i = 0; i < 100; i++)
            {
                myobjects.Add(System.Security.Cryptography.MD5.Create());
            }
