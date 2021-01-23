    public CreditoStruct RegresaDatosCredito(int idC)
    {
        return (from a in context.acreditados
                                 where a.creditos.IDCredito == idC
                                 select new CreditoStruct
                                 {
                                     Monto = a.Cantidad,
                                     Tasa = a.creditos.TasaInteres,
                                     Plazo = a.creditos.Plazo,
                                     Periodo = a.creditos.Periodo,
                                     Producto = a.creditos.Producto,
                                     Expediente = a.creditos.Expediente
                                 }).Single();
    }
