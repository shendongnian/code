     string str = "abc!";
                
                Encoding unicode = Encoding.Unicode;
                Encoding utf8 = Encoding.UTF8;
                
                byte[] unicodeBytes = unicode.GetBytes(str);
                
                byte[] utf8Bytes = Encoding.Convert( unicode,
                                                     utf8,
                                                     unicodeBytes );
                                                     
                Console.WriteLine( "UTF Bytes:" );
                StringBuilder sb = new StringBuilder();
                foreach( byte b in utf8Bytes ) {
                    sb.Append( b ).Append(" : ");
                }
                Console.WriteLine( sb.ToString() ); 
