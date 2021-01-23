    class MyObject
    {
        public MyCollection  TypeOnes;
        public MyCollection  TypeTwos;
        public MyCollection  TypeThrees;
    
        public MyCollection  All
        {
            get { return TypeOnes.Concat(TypeTwos.Concat(TypeThrees));}
            // You can use Union() to handle duplicates as well, but it's slower.
        }
    }
