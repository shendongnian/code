                    int[] values = new int[1000]
                    for (int i=0; i<999; i++)
                       values[i] = i;
    
                    values = Shuffle<int>(values);
                    foreach (int item in values)
                    {
                            Response.Write(item);
                    }
                    Response.Write("</br>");
                    values = Shuffle<int>(values);
                    foreach (int item in values)
                    {
                            Response.Write(item); //this will generate a unique random from 0-999
                    }
