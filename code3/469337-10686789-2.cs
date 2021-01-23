    namespace my.Models
    {
    public class WarrantBook
    {
        public int Id { get; set; } 
        public string Comment { get; set; }
        BookYear[] warrantYear = new BookYear[3];
        public BookYear[] WarrantYear
        {
            get { return warrantYear; }
            set { warrantYear = value; }
        }
    }
    public class EditableWarrantBook : WarrantBook  
    {
        public BookYear WarrantYear1
        {
            get { return WarrantYear[0]; }
            set { WarrantYear[0] = value; }
        }
        public BookYear WarrantYear2
        {
            get { return WarrantYear[1]; }
            set { WarrantYear[1] = value; }
        }
        public BookYear WarrantYear3
        {
            get { return WarrantYear[2]; }
            set { WarrantYear[2] = value; }
        }
    }
    public class BookYear
    {
        public int? StatusYear { get; set; } 
        public string Status { get; set; } 
    }
    public static class Ext
    {
        public static void CopyProperties(this EditableWarrantBook  source, WarrantBook destination)
        {
            // Iterate the Properties of the destination instance and   
            // populate them from their source counterparts   
            PropertyInfo[] destinationProperties = destination.GetType().GetProperties();
            foreach (PropertyInfo destinationPi in destinationProperties)
            {
                PropertyInfo sourcePi = source.GetType().GetProperty(destinationPi.Name);
                destinationPi.SetValue(destination, sourcePi.GetValue(source, null), null);
            }
        }
    }
