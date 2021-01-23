       [TestMethod]
        public void LogUmmappedConfiguration()
        {
            var mapper = new MapperConfiguration((cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            })).CreateMapper();
            var msg=ValidateUnmappedConfiguration(mapper) ;
            if (!msg.IsNullOrBlank())
            {
                TestContext.WriteString("Please review the list of unmapped fields and check that it is intentional: \n"+msg);
            }
        }
