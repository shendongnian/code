       if( ConnectionHandler.SqlConnect() )
          Using( SqlCeConnection conn = ConnectionHandler.GetConnection )
          {
             // do your stuff
          }
