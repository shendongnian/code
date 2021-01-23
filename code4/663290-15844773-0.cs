    [HttpPost]
    public ActionResult Eliminar(Usuario usuario)
    {
        db.Usuarios.Attach(usuario);
        db.Entry(usuario).Collection("Transacciones").Load();
        db.Entry(usuario).Collection("Eventos").Load();
        usuario.Transacciones.ToList().ForEach(t => db.Transacciones.Remove(t));
        usuario.Eventos.ToList().ForEach(e => db.Eventos.Remove(e));
        db.Usuarios.Remove(usuario);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
