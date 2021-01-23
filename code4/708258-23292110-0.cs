        lock ( listLock )
        {
            return friendList.Count;
        }
    }
    public  <b>static</b> SteamID GetFriendByIndex( int index )
    {
        lock ( listLock )
        {
            if ( index < 0 || index >= friendList.Count )
                return 0;
            return friendList[ index ];
        }
    }
