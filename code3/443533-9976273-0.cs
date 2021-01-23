    public override bool Equals(System.Object obj)
        {
            MyKey p = obj as MyKey;
            if ((System.Object)p == null)
            {
                return false;
            }
    
            // Return true if the fields match:
            return (row == p.row) && (col == p.col);
        }
