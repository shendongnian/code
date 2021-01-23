            for(int i = 0; i < fooBarObjects.Count; i++)
            {
                if(fooBarObjects[i] is bar1)
                {
                    ((bar1)fooBarObjects[i]).anotherMethodBar1();
                }
                else if (fooBarObjects[i] is bar2)
                {
                    ((bar2)fooBarObjects[i]).anotherMethodBar2();
                }
            }
