        public void ProcessCode( Code code )
        {
            switch ( CodeCheck.GetType( code ) )
            {
                case Type.Control:
                    // do something
                    break;
                case Type.Notification:
                    // do something
                    break;
            }
        }
