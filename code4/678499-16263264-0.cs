       if (ObjReader != null)
       {
           while (ObjReader.Read())
           {
            VolT0 = !ObjReader.IsDBNull(0)?ObjReader.GetValue(0).ToString():string.Empty;
            VolK0 = !ObjReader.IsDBNull(1)?ObjReader.GetValue(1).ToString():string.Empty;
            VolK1 = !ObjReader.IsDBNull(2)?ObjReader.GetValue(2).ToString():string.Empty;
           }
       }
