           public struct Cordination
           {
               public int A;
               public int B;
    
               public Cordination(int a, int b)
               {
                    A = a;
                    B = b;
               }
           }
            public float distanceInMeter(Cordination[] cordination)
            {
                float minDistance = float.MaxValue;
                for (int i = 0; i < cordination.Length - 1; i++)
                {
                    for (int j = i + 1; j < cordination.Length; j++)
                    {
                        float dist = (float)Math.Sqrt(Math.Pow(cordination[i].A - cordination[j].A, 2.0) + Math.Pow(cordination[i].B - cordination[j].B, 2.0));
                        if (dist < minDistance)
                            minDistance = dist;
                    }
                }
                return minDistance;
            }
