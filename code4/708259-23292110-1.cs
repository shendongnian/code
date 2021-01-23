    public static int GetFriendCount()
        {
            lock ( listLock )
            {
                return friendList.Count;
            }
        }
        public  static SteamID GetFriendByIndex( int index )
        {
            lock ( listLock )
            {
                if ( index < 0 || index >= friendList.Count )
                    return 0;
    
                return friendList[ index ];
            }
        }
