    class Program {
        static void Main( string[ ] args ) {
            Attribute attribute = new Attribute( );
            attribute[ "string1" ] = true;
            attribute[ "string2" ] = false;
            Console.WriteLine( attribute[ "string1" ] ); //True
            Console.WriteLine( attribute[ "string2" ] ); //True        
            Console.WriteLine( attribute[ "string3" ] ); //False
        }
    }
    class Attribute {
        private List<string> m_data;
        public Attribute(){
            m_data = new List<string>();
        }
        public bool this[ string s ] {
            get { return this.m_data.Contains( s ); }
            set { this.m_data.Add( s ); }
        }
    }
