        public static StringBuilder odczyt(string nazwa)
        {
            FileStream plik;
            StringBuilder dane = new StringBuilder("");
            try
            {
                plik = new FileStream(nazwa, FileMode.Open);
                int w;
                do
                {
                    w = plik.ReadByte();
                    if (w != -1)
                        dane.Append((char)w);
                }
                while ((w > 0));
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Brak pliku {0}", nazwa);
            }
            finally
            {
                if (plik != null)
                {
                    plik.Close();
                }
            }
            return dane;
        }
