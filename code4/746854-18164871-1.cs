    class PACK_Comparer : EqualityComparer<PACK>
    {
        public override bool Equals(PACK p1, PACK p2)
        {
            // Two PACK are Equals if their INVENTORYs contains the same INVENTORY items
            return (p1.INVENTORY_PACK.Count() == p2.INVENTORY_PACK.Count()
                && p1.INVENTORY_PACK.Intersect(p2.INVENTORY_PACK, new INVENTORY_PACK_Comparer()).Count() == p1.INVENTORY_PACK.Count());
        }
        public override int GetHashCode(PACK p)
        {
            // Ensure that if the Equals method returns true for two PACK p1 and p2
            // then the value returned by the GetHashCode method for p1 must equal the value returned for p2
            INVENTORY_PACK_Comparer comp = new INVENTORY_PACK_Comparer();
            int hCode = 0;
            foreach (var i in p.INVENTORY_PACK)
                hCode ^= comp.GetHashCode(i);
            return hCode.GetHashCode();
        }
    }
    class INVENTORY_PACK_Comparer : EqualityComparer<INVENTORY_PACK>
    {
        public override bool Equals(INVENTORY_PACK i1, INVENTORY_PACK i2)
        {
            // Two INVENTORY_PACK are Equals if their INVENT_ITEM_STATE, CARD_IDE and QTY are Equals
            return (i1.INVENTORY.INVENT_ITEM_STATE == i2.INVENTORY.INVENT_ITEM_STATE
                && i1.INVENTORY.CARD_IDE == i2.INVENTORY.CARD_IDE
                && i1.QTY == i2.QTY);
        }
        
        public override int GetHashCode(INVENTORY_PACK i)
        {
            // Ensure that if the Equals method returns true for two INVENTORY_PACK i1 and i2
            // then the value returned by the GetHashCode method for i1 must equal the value returned for i2
            int hCode = i.INVENTORY.INVENT_ITEM_STATE.GetHashCode()
                ^ i.INVENTORY.CARD_IDE.GetHashCode()
                ^ i.QTY.GetHashCode();
            return hCode.GetHashCode();
        }
    }
