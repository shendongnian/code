    catch (DbEntityValidationException ex)
    {
        foreach (var errors in ex.EntityValidationErrors)
        {
            foreach (var validationError in errors.ValidationErrors)
            {
                 // get the error message 
                string errorMessage = validationError.ErrorMessage;
            }
        }
    }
