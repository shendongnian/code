    class Item
    {
        public string Name { get ; private set ; }
        public int    Amount { get ; private set ; }
        public Item( string name , int amount )
        {
            if ( string.IsNullOrWhiteSpace(name) ) throw new ArgumentException("name") ;
            if ( amount < 0 ) throw new ArgumentException("amount") ;
            this.Name = name ;
            this.Amount = amount ;
            return ;
        }
    }
    static void Main( string[] args )
    {
        Random rng   = new Random() ;
        Item[] items = { new Item( "item--0"  , 3000000 ) ,
                         new Item( "item-25"  , 1500000 ) ,
                         new Item( "item-50"  , 2000000 ) ,
                         new Item( "item-75"  ,  300000 ) ,
                         new Item( "item-100" ,   10000 ) ,
                         new Item( "item-150" ,   10000 ) ,
                        } ;
        int    total = items.Sum( x => x.Amount ) ;
        for ( int i = 0 ; i < 100 ; ++i )
        {
            int  r = rng.Next(0, total ) ; // get a random integer x such that 0 <= x < total
            int  n = 0 ;
            Item selected = null ;
            int  lo = 0 ;
            int  hi = 0 ;
            for ( int j = 0 ; j < items.Length ; ++j )
            {
                lo = n ;
                hi = n + items[j].Amount ;
                n  = hi ;
                if ( r < n )
                {
                    selected = items[j] ;
                    break ;
                }
            }
            Console.WriteLine( "iteration {0}. r is {1} <= {2} < {3}. Selected item is {4}" ,
                i ,
                lo ,
                r ,
                hi ,
                selected.Name
                ) ;
        }
        return;
    }
