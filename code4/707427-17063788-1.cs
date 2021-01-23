            for(int i = 0; i < fooBarObjects.Count; i++)
            {
                var b1 = fooBarObjects[i] as bar1;
                if  (b1 != null)
                {
                    b1.anotherMethodBar1();
                }
                else
                {
                    var b2 = fooBarObjects[i] as bar2;
                    if (b2 != null)
                    {
                        b2.anotherMethodBar2();
                    }
                }
            }
