    var lista =
      (from a in db.Usuario.AsQueryable()
      join b in db.UsuarioAcesso.AsQueryable() on a.UsuarioID equals b.UsuarioID   
      select new
      {
          a.UsuarioID,
          a.Nome,
          a.Login,
          a.Email
      })
      .OrderBy(aOrderna + " " + aOrdenaTipo)
      .Skip(aIniciarNoRegistro)
      .Take(aQtdeRegistro);
