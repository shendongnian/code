    public static List<BillsDataSet> BillsPorFecha(DateTime dtFechaInicial, DateTime dtFechaFinal)
    {
        Context db = new Context();
        List<BillsDataSet> BillsDataSet = (from p in db.Bill
                                               select new BillsDataSet()
                                               {
                                                   IDGestion = p.IDBill,
                                                   Comentario = p.Historial.FirstOrDefault().Comentario,
                                                   Products = (from b in db.BillProduct where b.product_id == p.IDBill select new BillProduct()).ToList() as ICollection<BillProduct>,
                                                   Monto = p.Total,
                                                   Personal = p.Historial.FirstOrDefault().CodigoEmpleado
                                               }).ToList();
        return BillsDataSet;
}
    
