    var consulta = contexto.tb_usuario.Where(whatever).OrderBy(whatever)
                       .Select(t => new UsuarioData
                                    {
                                         UsuLogin = t.usu_login,
                                         UsuName = t.usu_name
                                    }
                               );
    return consulta.ToList();
