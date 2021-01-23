        // not tested
        [WebMethod]
        public string hello(params int[] list)
        {
            string s = "Hello\n";
            // do some stuff with your ints
            for ( int i = 0 ; i < list.Length ; i++ )
              s += list[i] + "\n" ;
        
            return s;
        }
