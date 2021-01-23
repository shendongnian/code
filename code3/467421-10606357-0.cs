            int places = 4;
            Double totalpossibilities = Math.Pow(2, places);
            for (int i = 0; i < totalpossibilities; i++)
            {
                string CurrentNumberBinary = Convert.ToString(i, 2).PadLeft(places, '0');
                CurrentNumberBinary = CurrentNumberBinary.Replace('0', 'x');
                CurrentNumberBinary = CurrentNumberBinary.Replace('1', 'y');
                Debug.WriteLine(CurrentNumberBinary);
            }
