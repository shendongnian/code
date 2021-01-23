            public void TestPoints()
            {
                List<Point> temp = new List<Point>();
                List<Point> visited = new List<Point>();
                List<Point> points = new List<Point>();
                points.Add(new Point(100, 100));
                points.Add(GeneratePoint());
                points.Add(GeneratePoint());
                points.Add(GeneratePoint());
                points.Add(GeneratePoint());
    
    
                //other initialization
                for (int i = 0; i < points.Count; i++)
                {
                    if (temp.Count != 0)
                        temp.Clear(); //Problem occurs here
                    temp.Add(GeneratePoint());
                    temp.Add(GeneratePoint());
                    temp.Add(GeneratePoint());
                    temp.Add(GeneratePoint());
                    while (!(visited.Contains(temp[0]) && visited.Contains(temp[1])))
                    {
                        //calculate some stuff
                        for (int j = 0; j < 4; j++)
                            visited.Add(temp[j]);
                        //use point of interests
                        temp.Clear(); //no issue on this clear
                        temp.Add(GeneratePoint());
                        temp.Add(GeneratePoint());
                        temp.Add(GeneratePoint());
                        temp.Add(GeneratePoint());
                    }
                    //display results
                }
            }
            public Point GeneratePoint()
            {
                return new Point((new Random()).Next(1, 100), (new Random()).Next(1, 100));
            }
