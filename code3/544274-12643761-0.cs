    public static DailyDetailReports CloneLists(DailyDetailReports listToClone)
            {
                DailyDetailReports clonedList = new DailyDetailReports();
    
                clonedList.Rec.AddRange(PerformTheCloning(listToClone.Rec));
                clonedList.Dil.AddRange(PerformTheCloning(listToClone.Dil));
                clonedList.Acc.AddRange(PerformTheCloning(listToClone.Acc));
                clonedList.Out.AddRange(PerformTheCloning(listToClone.Out));
    
                return clonedList;
            }
    
        public static List<T> ListCloning<T>(List<T> listToClone)
                {
                    PropertyInfo[] listToCloneProperties = listToClone.GetType().GetGenericArguments().First().GetProperties();
        
                    try
                    {
                        List<T> clonedList = new List<T>();
        
                        foreach (object t in (IEnumerable<object>)listToClone)
                        {
                            object clonedListRecord = Activator.CreateInstance(typeof(T), null);
        
                            foreach (PropertyInfo t1 in listToCloneProperties)
                            {
                                PropertyInfo clonedListProperty =
                                    clonedListRecord.GetType().GetProperties().FirstOrDefault(record=> record.Name == t1.Name);
        
                                if (clonedListProperty != null)
                                    clonedListProperty.SetValue(clonedListRecord, t1.GetValue(t, null), null);
                            }
        
                            clonedList.Add((T)clonedListRecord);
                        }
                    
                        return clonedList;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
        
                    return null;
                }
