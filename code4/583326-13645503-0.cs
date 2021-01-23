        class Data {
            public int ID;
            public int value;
        }
        enum RowState {
            Added,
            Updated,
            Deleted
        }
        List<Data> OldDataTable = new List<Data> { 
                new Data { ID = 1, value = 0 }, 
                new Data { ID = 2, value = 0 }, 
                new Data { ID = 3, value = 1 } 
        };
        List<Data> NewDataTable = new List<Data> { 
                new Data { ID = 1, value = 0 },
                new Data { ID = 2, value = 1 },
                new Data { ID = 4, value = 2 } 
        }; 
        void Test() {
            //updated and deleted rows
            var udRows = 
                from Old in OldDataTable
                join n in NewDataTable on Old.ID equals n.ID 
                into NewWithNullForDeleted
                from subNew in NewWithNullForDeleted.DefaultIfEmpty()
                where subNew == null || Old.value != subNew.value
                select new {
                    ID = Old.ID,
                    OldValue = (int?)Old.value,
                    NewValue = subNew == null ? (int?)null : (int?)subNew.value,
                    RowState = subNew == null ? RowState.Deleted : RowState.Updated
                };
            //added rows
            var aRows = 
                from New in NewDataTable
                join o in OldDataTable on New.ID equals o.ID 
                into OldWithNullForAdded
                from subOld in OldWithNullForAdded.DefaultIfEmpty()
                where subOld == null
                select new {
                    ID = New.ID,
                    OldValue = (int?)null,
                    NewValue = (int?)New.value,
                    RowState = RowState.Added
                };
            //merge
            var changedRows = udRows.ToList();
            changedRows.AddRange(aRows);
            //display
            foreach (var changedRow in changedRows) {
                Console.WriteLine("{0} : '{1}' -> '{2}' ({3})",
                changedRow.ID, 
                changedRow.OldValue, changedRow.NewValue,
                changedRow.RowState);
            }
        }
