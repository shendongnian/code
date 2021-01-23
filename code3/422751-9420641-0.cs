        public something FindUserByUserName( string UserName )
        {
            using ( var searcher = 
                new PrincipalSearcher( new UserPrincipal( ConfigurationContext ) { Name = UserName } ) )
            {
                var item = searcher.FindOne();
                // do whatever you want with the found object and return it
            }
        }
