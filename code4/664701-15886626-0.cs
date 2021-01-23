    // GET api/actions
        public object Get()
        {
            //New up a strongly typed object if you want to return a specific type
            //and change Action return type accordingly
            var testObjet = new (){
                             Name= "Test name",
                             Description= "Test Description"
                             };
            return testObjet;
            
        }
