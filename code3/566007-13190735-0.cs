        using (StreamReader sr = new StreamReader(@"C:\Users\Administrator\Documents\test.txt"))
        {
            int[] ZeroArray = null;
            int[] ThirdArray = null;
            int[] ZeroArrayTemp = null;
            int[] ThirdArrayTemp = null;
            int[] tempZero = null;
            int[] tempThird = null;
            int i = 0;
            do
            {
                i++;
                string line = sr.ReadLine();
                string[] values = line.Split(',');
                //get value for ZeroArray
                int valueZero = int.Parse(values[0]);
                //get value for ThirdArray
                int valueThird = int.Parse(values[2]);
                ZeroArrayTemp = new int[i + 1];
                ThirdArrayTemp = new int[i + 1];
                if (tempZero != null)
                {
                    for (int j = 0; j < tempZero.Length - 1; j++)
                    {
                        ZeroArrayTemp[j] = tempZero[j];
                    }
                }
                if (tempThird != null)
                {
                    for (int j = 0; j < tempThird.Length - 1; j++)
                    {
                        ThirdArrayTemp[j] = tempThird[j];
                    }
                }
                ZeroArrayTemp.SetValue(valueZero, i - 1);
                ThirdArrayTemp.SetValue(valueThird, i - 1);
                tempZero = ZeroArrayTemp;
                tempThird = ThirdArrayTemp;
  
            }while(sr.Peek() != -1);
            //Copy valid value to final array
            ZeroArray = new int[ZeroArrayTemp.Length - 1];
            Array.Copy(ZeroArrayTemp, ZeroArray, ZeroArrayTemp.Length - 1);
            ThirdArray = new int[ThirdArrayTemp.Length - 1];
            Array.Copy(ThirdArrayTemp, ThirdArray, ThirdArrayTemp.Length - 1);
        }
