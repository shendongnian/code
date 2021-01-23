     using (var context = new EntityBazaCRM(Settings.sqlDataConnectionDetailsCRM))
            {
                IQueryable<SzkolenieMiejsca> listaMiejsc = from d in context.SzkolenieMiejscas
                                                                        select d;
                ComboBoxItemCollection collection = comboBox.Properties.Items;
                collection.BeginUpdate();
                foreach (var miejsce in listaMiejsc)
                {
                    collection.Add(miejsce);
                }
                collection.EndUpdate();
                comboBox.SelectedIndex = -1;
            }
