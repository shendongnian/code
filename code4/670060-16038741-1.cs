    ClasesProClean.OrdenCompra Orden = HO.getOrdenCompra(orden);
    DataContractJsonSerializer serializer =  new DataContractJsonSerializer(Orden.GetType());
    System.IO.MemoryStream ms = new System.IO.MemoryStream();
    serializer.WriteObject(ms, Orden);
    String json = Encoding.Default.GetString(ms.ToArray());
