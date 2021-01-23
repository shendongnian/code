    public class BetList : Collection<Bet>
    {
        public uint Sum { get; private set; }
        protected override void ClearItems()
        {
            Sum = 0;
            base.ClearItems();
        }
        protected override void InsertItem(int index, Bet item)
        {
            Sum += item.Amount;
            base.InsertItem(index, item);
        }
        protected override void RemoveItem(int index)
        {
            Sum -= item.Amount;
            base.RemoveItem(index);
        }
        protected override void SetItem(int index, Bet item)
        {
            Sum -= this[i].Amount;
            Sum += item.Amount;
            base.SetItem(index, item);
        }
    }
