            private Nullable<int> ToInt1900ForExcel(DateTime DT)
        {
            if (DT < new DateTime(1900,1,1))//Below 1900-1-1, Excel has some problems representing dates, search it on the web.
                return null;
            if (DT < new DateTime(1900,3,1))//Excel reproduced a bug from Lotus for compatibility reasons, 29/02/1900 didn't actually exist.
                return (int)(DT.ToOADate()) - 1;
            return (int)(DT.ToOADate());
        }
