    Set<TableBObject>(x => x.TableBRecordsABCDOnly, map =>
                {
                    
                    map.Inverse(true);
                    map.Cascade(Cascade.All);
                    map.Key(k => k.Column(c => c.Name("TableAFKey")));
                    map.Where("TableBColumn1 = 'ABCD'");
                },
                action => action.OneToMany());
