    public class ServiceController : ApiController
    {
            [HttpGet]
            public string Get(int id)
            {
                return "object of id id";
            }
            [HttpGet]
            public IQueryable<DropDownModel> DropDowEmpresa()
            {
                return db.Empresa.Where(x => x.Activo == true).Select(y =>
                      new DropDownModel
                      {
                          Id = y.Id,
                          Value = y.Nombre,
                      });
            }
            [HttpGet]
            public IQueryable<DropDownModel> DropDowTipoContacto()
            {
                return db.TipoContacto.Select(y =>
                      new DropDownModel
                      {
                          Id = y.Id,
                          Value = y.Nombre,
                      });
            }
            [HttpGet]
            public string FindProductsByName()
            {
                return "FindProductsByName";
            }
    }
