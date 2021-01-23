     if (input[0].Contains("-s"))
            {
                variant = 1; 
            }
     if (!String.IsNullOrWhiteSpace(input[1]) && !String.IsNullOrWhiteSpace(input[2]))
                {
                    variant = 2;        
                }
     if (!String.IsNullOrWhiteSpace(input[3]))
                {
                    variant = 3;
                }
            return variant;
