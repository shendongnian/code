    public static class Extentions {
        public static DataTable Clone(this DataGridView oldDGV) {
            DataGridView newDGV = new DataGridView();
            newDGV.Size = oldDGV.Size;
            newDGV.Anchor = oldDGV.Anchor;
            
            return newDGV;
        }
    }
