        public bool Compare(Byte[] array1, Byte[] array2)
        {
            if (array1.Count() != array2.Length)
                return false;
            
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                    return false;
            }
            return true;            
        }
