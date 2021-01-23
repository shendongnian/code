    public string JsongetOrdenCompra(String orden)
    {
        try
        {
            var data = this._Collection.FindOneAs<OrdenCompra>(Query.EQ("NumOrden", orden));
            var s = new System.Web.Script.Serialization.JavaScriptSerializer();
            var result = s.Serialize(data);
            return result;
            // Alternatively, ServiceStack.Text.JsSerializer or 
            // extension methods like ASP.NET MVC's Json()
        }
        catch (Exception e)
        {
            throw new Exception("Error al obtener Orden de Compra. \n"+e.Message);
        }
    }
