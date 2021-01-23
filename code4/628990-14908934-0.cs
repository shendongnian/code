    // Ready-room state
    connection1 = WaitForAndGetConnection();
    connection2 = WaitForAndGetConnection();
    SendMessage( connection1, "JOINED" ); // inform player 1 that another player joined
    
    p1Ready = false, p2Ready = false;
    while(message = GetLastIncomingMessage() && !p1Ready && !p2Ready) {
        if( message.From == connection1 && message.Verb == "READY" ) p1Ready = true;
        if( message.From == connection2 && message.Verb == "READY" ) p2Ready = true;        
    }
    
    SendMessage( connection1, "ISREADY" ); // inform the players the game has started
    SendMessage( connection2, "ISREADY" ); // inform the players the game has started
    
    // Game playing state
    TicTacToeBoard board = new TicTacToeBoard(); // this class represents the game state and game rules
    
    p1Move = true; // indicates whose turn it is to move
    while(message = GetLastIncomingMessage()) {
        
        if( message.Verb == "MOVE" ) {
        
            if( p1Move && message.From == connection1 ) {
                 if( board.Player1Move( message.X, message.Y ) ) {
                    SendMessage( connection1, "MOVED (1, " + message.X + "," + message.Y + " )");
                    SendMessage( connection2, "MOVED (1, " + message.X + "," + message.Y + " )");
                    p1Move = false;
                } else {
                    SendMessage( message.From, "DENIED \"Disallowed move.\".");
                }
                
            } else if( !p1Move && message.From == connection2 ) {
                
                if( board.Player2Move( message.X, message.Y ) ) {
                    SendMessage( connection1, "MOVED (2, " + message.X + "," + message.Y + " )");
                    SendMessage( connection2, "MOVED (2, " + message.X + "," + message.Y + " )");
                    p1Move = true;
                } else {
                    SendMessage( message.From, "DENIED \"Disallowed move.\".");
                }
                
            } else {
                SendMessage( message.From, "DENIED \"It isn't your turn to move\".");
            }
            if( board.IsEnded ) { 
                // handle game-over...
            } 
        } else if( message.Verb == ... // handle all of the other verbs, like QUIT 
        }
    }
