    private void buttonAgregar_Click(object sender, RoutedEventArgs e)
    {
        var cliente = new Cliente
        {
            Nombre = textBoxNombre.Text,
            Apellido1 = textBoxPrimerApellido.Text,
            Apellido2 = textBoxSegundoApellido.Text,
        };
        db.Clientes.Add(cliente);
        try
        {
            db.SaveChanges();
        }
        catch (System.Data.Entity.Validation.DbEntityValidationException exc)
        {
            String mensaje = "";
            foreach (var validationErrors in exc.EntityValidationErrors)
                foreach (var validationError in validationErrors.ValidationErrors)
                    mensaje += validationError.ErrorMessage + "\n";
            db.Entry(cliente).State = EntityState.Detached;
            MessageBox.Show(mensaje, "Se han encontrado errores", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
