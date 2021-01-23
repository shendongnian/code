    private static T CreateInstance<T>(string fullyQualifiedClassName)
    {
        try
        {
            return (T)Activator.CreateInstance(Type.GetType(fullyQualifiedClassName));
        }
        catch (Exception ex)
        {
            clsAdmFunctions.RecordException(ex); // Record error to the database
            MessageBox.Show("Error instantiating the object\n\nDescription : " + ex.Message, "Object Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return default(T);
        }
    }
