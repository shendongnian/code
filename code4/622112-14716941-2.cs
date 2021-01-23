    public static class SelectableFactory
    {
        public static Selectable GetFromDataRow(DataRow dr)
        {
            Selectable res = null;
            switch (dr.Type)
            {
                case "Department":
                    res = new Department(dr);
                    // etc ...
                }
        }
    }
