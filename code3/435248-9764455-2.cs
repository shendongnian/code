       public ItemMovementEntry(ItemMovementEntryKind comparerMovementKind,
                        DateTime documentDate,
                        string documentLKey,
                        string materialItemKey,
                        int movementDeltaQty,
                        string comment)
                : this(comparerMovementKind)
            {
                ItemMovementEntryPhase p = null;
                switch (comparerMovementKind)
                {
                    case ItemMovementEntryKind.Sales:
                        p = this.SoldPhase;
                        break;
                    case ItemMovementEntryKind.Picking:
                        p = this.PickedPhase;
                        break;
                    case ItemMovementEntryKind.Dispatch:
                        p = this.DispatchedPhase;
                        this.JournalType = "DISPATCHED";
                        break;
                }
                p.DocumentDate = documentDate;
                p.DocumentLKey = documentLKey;
                this.MaterialItemLkey = materialItemKey;
                p.MovementDeltaQty = movementDeltaQty;
                p.Comment = comment;
            }
        public List<ItemMovementEntry> FillItemDispatchMovements(IEntityDateRange imqp)
        {
            var f = from detail in this.Context.DispatchDetails
                    join header in this.Context.Dispatches on detail.ClientOrderNumber equals header.ClientOrderNumber
                    where (detail.ProductCode == imqp.ItemKey)
                     && (header.DateOrdered >= imqp.StartDate)
                     && (header.DateOrdered <= imqp.EndDate)
                    orderby header.DateOrdered descending
                    select new ItemMovementEntry(ItemMovementEntryKind.Dispatch,
                        ((header.DateOrdered.HasValue) ? header.DateOrdered.Value : new DateTime(1900, 1, 1)),
                        header.ClientOrderNumber,
                        detail.ProductCode,
                        ((detail.QuantityDelivered.HasValue) ? (-1) * detail.QuantityDelivered.Value : 0),
                        string.Empty){};
            return f.ToList<ItemMovementEntry>();
        }
