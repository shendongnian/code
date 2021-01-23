                if (col.GetType() == typeof(DataGridTextColumn))
                {
                    col.IsReadOnly = true;
                }
                else
                {
                    col.IsReadOnly = false;
                }
            }
