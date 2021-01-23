    public static class Utilities{
        public static object CloneObject(this DataGridViewColumnHeaderCell myObj){
             DataGridViewColumnHeaderCell clonedObject = new DataGridViewColumnHeaderCell();
             //here clone your properties
             clonedObject.ColumnIndex = myObj.ColumnIndex;              
             return clonedObject;
        }
    }
