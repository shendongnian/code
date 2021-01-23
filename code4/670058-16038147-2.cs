    public ActionResult JsongetOrdenCompra(String orden)
    {
        // Assuming ASP.NET MVC
        try
        {
            var data = this._Collection.FindOneAs<OrdenCompra>(Query.EQ("NumOrden", orden));
            var dto = AutoMapper.Mapper.DynamicMap<OrdenReadDTO>(dto);
            return Json(dto);
        }
        catch (Exception e)
        {
            throw new Exception("Error al obtener Orden de Compra. \n"+e.Message);
        }
    }
