    public class OrdenDTO 
    {
        public String Proveedor { get; set; }
        public String EmitidaPor { get; set; }
    }
    public class OrdenReadDTO : OrdenDTO
    {
        public ObjectId Id { get; set; }
    }
    {
    ...
      var data = this._Collection.FindOneAs<OrdenCompra>(Query.EQ("NumOrden", orden));
      var dto = AutoMapper.Mapper.DynamicMap<OrdenReadDTO>(dto);
      var s = new System.Web.Script.Serialization.JavaScriptSerializer();
      var string = s.Serialize(data);
      return string;
    }
