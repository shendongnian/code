        class TestInfo
        {
            public TeamCode{set;get;}
            public TeamName{set;get;}
        }
        Info objInfo=new Info();
        objInfo=serializer.Deserialize<TestInfo>(Info);
