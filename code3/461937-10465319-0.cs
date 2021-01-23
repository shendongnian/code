    bool spr_wiersz(int wiersz, int kolumna) 
            {
                wys_tab();
                Console.WriteLine("wiersz: {0}, kolumna: {1}", wiersz, kolumna);
                int i_wiersz=0;
                bool[] result = new bool[9];
                while (i_wiersz < 9)
                {
                    subscribers.ForEach(delegate(ImessageCallback callback)
                    {
                        if (((ICommunicationObject)callback).State == CommunicationState.Opened)
                        {
                            Console.WriteLine("wiersz: {0}, kolumna: {1}, i: {2}", wiersz, kolumna, i_wiersz);
                            result[i_wiersz] = callback.spr_wiersz(wiersz, kolumna, i_wiersz);
                            i_wiersz++;
                        }
                    });
                    for (int j = 0; j < i_wiersz; j++)
                    {
                        if (result[j] == false)
                        {
                            return false;
                            
                        }
                    }
                    
                }
                return true;
            }
