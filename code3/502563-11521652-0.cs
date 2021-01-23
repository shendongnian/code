                int abc = 1;
                switch (abc)
                {
                    case 1:
                        {
                            var x = 11;
                        }
                        break;
                    case 2:
                        {
                            var x = 11; // its legal. 
                        }
                        break;
                    case 3:
                        var xx = 11; // its ilegal here too.. because we already have it in previous scope. 
                        break;
                    case 4:
                        {
                            var x = 11; // its illegal here because we already have a in the parent/current scope. 
                        }
                        break;
                }
