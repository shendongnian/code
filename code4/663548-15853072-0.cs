    var positions = new List<Tuple<int, int>>();
    
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        if (n.getPuzzle()[x,y] == 0)
                        {
                            positions.Add(new Tuple<int, int>(x,y));
                            break;
                        }
                    }//end y loop
                }//end x loop
    
                if(positions.Any())
                {
                    var xpos = positions[0].Item1;
                    var ypos = positions[0].Item2;
                }
