    public static bool IsFaxNumber(string faxNo)
        {
            bool returnValue = false;
            var items = faxNo.Split(' ');
            if (faxNo.Length == 13 && items.Length == 3)
                if (items[0].Length == 4 && items[1].Length == 3 && items[2].Length == 4)
                    returnValue = true;
            return returnValue;
        }
