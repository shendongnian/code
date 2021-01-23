    public class TShirtSizeComparer : Comparer<object>
    {
        // Compares TShirtSizes and orders them by size
        public override int Compare(object x, object y)
        {
            var _sizesInOrder = new List<string> { "None", "XS", "S", "M", "L", "XL", "XXL", "XXXL", "110 cl", "120 cl", "130 cl", "140 cl", "150 cl" };
            var indexX = -9999;
            var indexY = -9999;
            if (x is TShirt)
            {
                indexX = _sizesInOrder.IndexOf(((TShirt)x).Size);
                indexY = _sizesInOrder.IndexOf(((TShirt)y).Size);
            }
            else if (x is TShirtListViewModel)
            {
                indexX = _sizesInOrder.IndexOf(((TShirtListViewModel)x).Size);
                indexY = _sizesInOrder.IndexOf(((TShirtListViewModel)y).Size);
            }
            else if (x is MySelectItem)
            {
                indexX = _sizesInOrder.IndexOf(((MySelectItem)x).Value);
                indexY = _sizesInOrder.IndexOf(((MySelectItem)y).Value);
            }
            if (indexX > -1 && indexY > -1)
            {
                return indexX.CompareTo(indexY);
            }
            else if (indexX > -1)
            {
                return -1;
            }
            else if (indexY > -1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
