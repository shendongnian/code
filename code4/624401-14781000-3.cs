        public static MyNode Transform( this Node node )
        {
            return Mapper.Map( node.GetType(), node.GetMatchingMyType(), node );
        }
        public static Type GetMatchingType( this Node node )
        {
            // you can use a dictionary lookup or some other logic if this doesn't work
            var typeName = "My" + node.GetType().Name;
            return typeof(MyNode).Assembly.GetTypes().Single( t => t.Name == typeName );
        }
