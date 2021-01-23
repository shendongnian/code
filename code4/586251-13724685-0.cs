    public class Pickups
    {
        public string name { get; set; }
        public string address { get; set; }
        public string Dname { get; set; }
        public string Daddress { get; set; }
        public string type { get; set; }
        public DateTime arrival { get; set; }
        public DateTime Lat { get; set; }
        public DateTime Lon1 { get; set; }
    }
    class Program
    {
        
        static void Main()
        {
            Pickups thePickup = new Pickups();
            thePickup.name = "nameProp";
            thePickup.address = "addressProp";
            thePickup.arrival = DateTime.Now;
            thePickup.Dname = "txtDeliveryName";
            thePickup.Daddress = "txtDaddress";
            thePickup.Lat = DateTime.Now;
            thePickup.Lon1 = DateTime.Now;
            thePickup.type = "Pickup";
            //Update thePickup object to reflect any changes made by the user
            XmlSerializer SerializerObj = new XmlSerializer(typeof(Pickups));
            using (TextWriter WriteFileStream = new StreamWriter(@"Pickups.xml", true))
            {
                SerializerObj.Serialize(WriteFileStream, thePickup);
            }
            Pickups thePickup1 = new Pickups();
            thePickup1.name = "nameProp2";
            thePickup1.address = "addressProp2";
            thePickup1.arrival = DateTime.Now;
            thePickup1.Dname = "txtDeliveryName2";
            thePickup1.Daddress = "txtDaddress2";
            thePickup1.Lat = DateTime.Now;
            thePickup1.Lon1 = DateTime.Now;
            thePickup1.type = "Pickup2";
            using (TextWriter WriteFileStream = new StreamWriter(@"Pickups.xml", true))
            {
                SerializerObj.Serialize(WriteFileStream, thePickup1);
            }
        }
    }
</pre>
