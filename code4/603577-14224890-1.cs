        public string Expression2()
        {
            return "One does not write maintainable code this way";
        }
        [Test]
        public void TryCatchAsSingleLine()
        {
            bool expr1 = true;
             // Would you say this is one line?
            string result = expr1 
                                ? (new Func<string>(() => 
                                                  { 
                                                     try 
                                                     { 
                                                        return Expression2(); 
                                                     } 
                                                     catch 
                                                     { 
                                                        return string.Empty; 
                                                     } 
                                                   }
                                                   )
                                 )() 
                                 : string.Empty;
        }
