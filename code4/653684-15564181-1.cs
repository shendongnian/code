        [WebMethod]
        public Site HelloWorld()
        {
            Site toReturn = new Site();
            toReturn.X = "hello world";
            return toReturn;
        }
