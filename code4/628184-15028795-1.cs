     public class XMLEntitiesSerializer
     {
       public string Serialize(XMLEntities.CompleteBooking completeBooking)
       {
         var serializedXml = string.Empty;
         var serializer = new XmlSerializer(typeof (XMLEntities.CompleteBooking));
         var stringWriter = new System.IO.StringWriter();
         try
         {
           serializer.Serialize(stringWriter, completeBooking);
           serializedXml = stringWriter.ToString();
         }
         catch(Exception ex)
         {
           //Log the stuff
         }
         finally
         {
           stringWriter.Close();
         }
         return serializedXml;
       }
     }
