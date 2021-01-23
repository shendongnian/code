        private void Convert()
        {
            A1 gm = new A1();
            gm.Name = "test";
            A2 LC = new A2();
            foreach(PropertyInfo pi in typeof(A).GetProperties())
            {
                pi.SetValue(LC,
                    pi.GetValue(gm, null)
                                , null);
            }
        }
