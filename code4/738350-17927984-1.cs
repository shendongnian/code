        try
        {
          repo.Save(model);
        }
        catch (DbEntityValidationException ex)
        {
          ModelState.AddModelError("EntityError", ex);
        }
