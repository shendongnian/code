    mainEntity = (EntityBase)navigationPropertyAnzeigeUserControl.SelectedObject;
                        IEnumerable<object> collection = (IEnumerable<object>)businnesObject.GetType().GetProperty("Positionen").GetValue(businnesObject, null);
                        List<object> test = collection.ToList();
                        test.Add(mainEntity);
                        businnesObject.GetType().GetProperty(LoescheAlleZeichenNachEinemGewissenZeichen(mainEntity.GetType().Name, '_')).SetValue(businnesObject, collection, null); 
