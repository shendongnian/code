If you have a large number of rows, then you could try creating a class that inherits from DataRow and override the Equals method. For example:    
    class CustomRow : DataRow
    {
        public override bool Equals(object obj)
        {
            if(obj.GetType() != typeof(CustomRow)) return false;
            for (int i = 0; i < ItemArray.Length; i++)
                if (((CustomRow)obj)[i] != this[i])
                    return false;
            return true;
        }
    }
