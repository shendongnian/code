    public class Program
    {
        static void Main()
        {
            var serializer = new XmlSerializer(typeof(HotelData));
            using (var reader = XmlReader.Create("test.xml"))
            {
                var data = (HotelData)serializer.Deserialize(reader);
                Console.WriteLine(data.Id);
                foreach (var hotel in data.Hotels)
                {
                    Console.WriteLine("num: {0}, item:{1}", hotel.Id, hotel.Item);
                }
            }
        }
    }
