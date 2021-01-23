    //If player 2 is connected
    if (GamePad.GetState(PlayerIndex.Two).IsConnected)
    {
        //If we can't find a signed in gamer with a PlayerIndex of two
        if (!Gamer.SignedInGamers.Cast<SignedInGamer>().Any(x => x.PlayerIndex == PlayerIndex.Two))
        {
            //Your handling code here
        }
    }
