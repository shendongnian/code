        public void UpdatePrintTime()
        {
            //This is a workaround to get past jquery validation errors when
            //attempting to edit a DateTime value directly with just a time string.
            DateTime dt = DateTime.MinValue;
            DateTime.TryParse("12/30/1899 " + sPrintTime.ToUpper(), out dt);
            if (dt != DateTime.MinValue)
            {
                PrintTime = dt;
            }
        }
        public void UpdatePrintString()
        {
            sPrintTime = PrintTime.ToString("h:mm tt");
        }
