    private static Form findOpenForm(Type typ)
        {
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (!Application.OpenForms[i].IsDisposed && (Application.OpenForms[i].GetType() == typ))
                {
                    return Application.OpenForms[i];
                }
            }
            return null;
        }
