    public ActionResult insertar(persona)
    {
        using (var context = new DBConext())
        {
            context.personas.Add(persona);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
