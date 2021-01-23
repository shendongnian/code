     using System.Reflection;  
      private void Convert(A1 _a1, A2 _a2)
        {
            foreach(PropertyInfo pi in typeof(A).GetProperties())
            {
                pi.SetValue(_a2,
                    pi.GetValue(_a1, null)
                                , null);
            }
            _a2.BeeList.Add(_a1.Bee);
        }
