    catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    Logger.WriteError("{0}{1}Validation errors:{1}{2}", ex, Environment.NewLine, ex.EntityValidationErrors.Select(e => string.Join(Environment.NewLine, e.ValidationErrors.Select(v => string.Format("{0} - {1}", v.PropertyName, v.ErrorMessage)))));
                    throw;
                }
